using System.Net;
using System.Text.Json;
using Sesparator.Web.Models.Api;

namespace Sesparator.Web.Services;

// Gemini'ye kullanıcının cümlesini gönderir, JSON olarak niyet/tutar/alıcı alır.
// Bakiye, limit gibi kontroller burada DEĞİL, BankaIslemServisi'nde yapılır.
public class GeminiNiyetServisi : INiyetServisi
{
    private const string TemelAdres = "https://generativelanguage.googleapis.com/v1beta/models/";
    private static readonly JsonSerializerOptions JsonAyari = new() { PropertyNameCaseInsensitive = true };

    private readonly HttpClient _http;
    private readonly IConfiguration _ayarlar;
    private readonly ILogger<GeminiNiyetServisi> _gunluk;

    public GeminiNiyetServisi(HttpClient http, IConfiguration ayarlar, ILogger<GeminiNiyetServisi> gunluk)
    {
        _http = http;
        _ayarlar = ayarlar;
        _gunluk = gunluk;

        var anahtar = ayarlar["Gemini:ApiAnahtari"]
            ?? throw new InvalidOperationException("Gemini:ApiAnahtari ayarlanmamış (Manage User Secrets).");
        _http.DefaultRequestHeaders.Add("x-goog-api-key", anahtar);
    }

    public async Task<NiyetSonucu> NiyetCikarAsync(string metin, IReadOnlyList<string> takmaAdlar)
    {
        var modeller = _ayarlar.GetSection("Gemini:NiyetModelleri").Get<string[]>() ?? [];
        var alicilar = takmaAdlar.Count > 0 ? string.Join(", ", takmaAdlar) : "(kayıtlı alıcı yok)";

        // 1) Talimat: modelin rolü ve kuralları
        var talimat = $"""
            Sen bir bankacılık asistanısın. Görevin SADECE kullanıcının ne istediğini anlamak.
            Niyetler:
            - {Niyetler.BakiyeSorgula}: bakiyesini öğrenmek istiyor.
            - {Niyetler.ParaTransferi}: birine para göndermek istiyor.
            - {Niyetler.Bilinmiyor}: diğer her şey.
            Para transferinde tutarı sayı olarak yaz ("beş yüz lira" -> 500, "1,5 bin" -> 1500).
            Alıcı şu kayıtlı alıcılardan biri olmalı: {alicilar}.
            Ek almış hâlini listedeki hâliyle aynen yaz ("anneme" -> "Annem"). Listede yoksa aliciTakmaAd yazma.
            Bakiye, tutar veya işlem sonucu uydurma.
            """;

        // 2) İstek gövdesi + cevabın uyması gereken JSON şeması
        var istek = new
        {
            systemInstruction = new { parts = new[] { new { text = talimat } } },
            contents = new[] { new { role = "user", parts = new[] { new { text = metin } } } },
            generationConfig = new
            {
                responseMimeType = "application/json",
                thinkingConfig = new { thinkingLevel = "low" },
                responseJsonSchema = new
                {
                    type = "object",
                    properties = new
                    {
                        niyet = new { type = "string", @enum = Niyetler.Tumu },
                        tutar = new { type = "number" },
                        aliciTakmaAd = new { type = "string" }
                    },
                    required = new[] { "niyet" }
                }
            }
        };

        // 3) Modelleri sırayla dene: yoğun (503) ya da kotası dolu (429) olanı atla
        JsonElement? json = null;
        foreach (var model in modeller)
        {
            using var yanit = await GonderAsync(model, istek);
            if (yanit is null) continue;   // zaman aşımı -> sıradaki model

            if (yanit.StatusCode is HttpStatusCode.TooManyRequests or HttpStatusCode.ServiceUnavailable)
            {
                _gunluk.LogWarning("Niyet modeli {Model} kullanılamadı ({Durum}), sıradakine geçiliyor",
                    model, (int)yanit.StatusCode);
                continue;
            }
            if (!yanit.IsSuccessStatusCode)
            {
                _gunluk.LogError("Gemini {Model} hata döndürdü ({Durum}): {Govde}",
                    model, (int)yanit.StatusCode, await yanit.Content.ReadAsStringAsync());
                yanit.EnsureSuccessStatusCode();   // HttpRequestException -> controller 502 döner
            }

            json = await yanit.Content.ReadFromJsonAsync<JsonElement>();
            break;   // cevap alındı, döngüden çık
        }

        // Hiçbir model cevap vermediyse controller 429 ve bu mesajı döndürür
        if (json is null)
            throw new KotaTukendiException("Asistan şu an çok yoğun, lütfen biraz sonra tekrar deneyin.");

        // 4) candidates[0].content.parts içindeki "text" alanı = modelin ürettiği JSON
        var jsonMetin = MetniBul(json.Value);
        if (jsonMetin == null) return new NiyetSonucu();

        // 5) JSON metnini C# nesnesine çevir
        try
        {
            return JsonSerializer.Deserialize<NiyetSonucu>(jsonMetin, JsonAyari) ?? new NiyetSonucu();
        }
        catch (JsonException)
        {
            _gunluk.LogWarning("Gemini niyet JSON'u okunamadı: {Metin}", jsonMetin);
            return new NiyetSonucu();   // BILINMIYOR
        }
    }

    // İsteği gönderir; zaman aşımında hata fırlatmak yerine null döner
    private async Task<HttpResponseMessage?> GonderAsync(string model, object istek)
    {
        try
        {
            return await _http.PostAsJsonAsync($"{TemelAdres}{model}:generateContent", istek);
        }
        catch (TaskCanceledException)
        {
            _gunluk.LogWarning("Niyet modeli {Model} zaman aşımına uğradı, sıradakine geçiliyor", model);
            return null;
        }
    }

    private static string? MetniBul(JsonElement json)
    {
        if (!json.TryGetProperty("candidates", out var adaylar) || adaylar.GetArrayLength() == 0) return null;
        if (!adaylar[0].TryGetProperty("content", out var icerik) ||
            !icerik.TryGetProperty("parts", out var parcalar)) return null;

        foreach (var parca in parcalar.EnumerateArray())
            if (parca.TryGetProperty("text", out var metin))
                return metin.GetString();
        return null;
    }
}