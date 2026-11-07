using System.Net;
using System.Text.Json;

namespace Sesparator.Web.Services;

// Gemini API ile STT ve TTS. İki iş de aynı uç noktaya gider, sadece model ve gövde değişir:
// POST https://generativelanguage.googleapis.com/v1beta/models/{model}:generateContent
public class GeminiSesServisi : ISesServisi
{
    private const string TemelAdres = "https://generativelanguage.googleapis.com/v1beta/models/";

    // TTS model listesi kaç kez baştan denenir
    private const int TtsTurSayisi = 2;

    private readonly HttpClient _http;
    private readonly IConfiguration _ayarlar;
    private readonly ILogger<GeminiSesServisi> _gunluk;

    public GeminiSesServisi(HttpClient http, IConfiguration ayarlar, ILogger<GeminiSesServisi> gunluk)
    {
        _http = http;
        _ayarlar = ayarlar;
        _gunluk = gunluk;

        var anahtar = ayarlar["Gemini:ApiAnahtari"]
            ?? throw new InvalidOperationException("Gemini:ApiAnahtari ayarlanmamış (Manage User Secrets).");
        // Anahtar URL'de değil header'da gider, böylece loglara düşmez
        _http.DefaultRequestHeaders.Add("x-goog-api-key", anahtar);
    }

    public async Task<string?> MetneCevirAsync(byte[] ses, string icerikTuru)
    {
        var model = _ayarlar["Gemini:SttModeli"]!;

        // Transcribe modeli talimat (systemInstruction) kabul etmiyor, sadece sesi gönderiyoruz
        var istek = new
        {
            contents = new[]
            {
                new { parts = new[] { new { inlineData = new { mimeType = icerikTuru, data = Convert.ToBase64String(ses) } } } }
            }
        };

        using var yanit = await _http.PostAsJsonAsync($"{TemelAdres}{model}:generateContent", istek);
        if (yanit.StatusCode == HttpStatusCode.TooManyRequests)
            throw new KotaTukendiException("Ses tanıma modelinin kotası tükendi.");
        await HataVarsaLogla(yanit, model);
        yanit.EnsureSuccessStatusCode();

        var json = await yanit.Content.ReadFromJsonAsync<JsonElement>();
        var parca = IlkParca(json);
        if (parca == null) return null;

        // Transcribe modeli metni "audioTranscription.text" içinde, normal modeller "text" içinde döndürür
        string? metin = null;
        if (parca.Value.TryGetProperty("audioTranscription", out var yaziya))
            metin = yaziya.GetProperty("text").GetString();
        else if (parca.Value.TryGetProperty("text", out var duzMetin))
            metin = duzMetin.GetString();

        return string.IsNullOrWhiteSpace(metin) ? null : metin.Trim();
    }

    public async Task<(byte[] Ses, string IcerikTuru)> SeseCevirAsync(string metin)
    {
        // Her TTS modelinin günlük kotası ayrı. Biri dolunca sıradakine geçilir;
        // liste bitince bir tur daha denenir, yine olmazsa kota hatası verilir.
        var modeller = _ayarlar.GetSection("Gemini:TtsModelleri").Get<string[]>() ?? [];
        var sesAdi = _ayarlar["Gemini:TtsSesi"];

        var istek = new
        {
            contents = new[] { new { parts = new[] { new { text = metin } } } },
            generationConfig = new
            {
                responseModalities = new[] { "AUDIO" },
                speechConfig = new { voiceConfig = new { prebuiltVoiceConfig = new { voiceName = sesAdi } } }
            }
        };

        for (var tur = 1; tur <= TtsTurSayisi; tur++)
        {
            foreach (var model in modeller)
            {
                using var yanit = await _http.PostAsJsonAsync($"{TemelAdres}{model}:generateContent", istek);

                // 429: kota doldu, 503: model yoğun. İkisinde de sıradaki modele geçilir.
                if (yanit.StatusCode is HttpStatusCode.TooManyRequests or HttpStatusCode.ServiceUnavailable)
                {
                    _gunluk.LogWarning("TTS modeli {Model} kullanılamadı ({Durum}), {Tur}. tur", model, (int)yanit.StatusCode, tur);
                    continue;
                }
                await HataVarsaLogla(yanit, model);
                yanit.EnsureSuccessStatusCode();

                var json = await yanit.Content.ReadFromJsonAsync<JsonElement>();
                var ses = IlkParca(json)?.GetProperty("inlineData")
                    ?? throw new HttpRequestException($"TTS modeli {model} ses döndürmedi.");

                var veri = Convert.FromBase64String(ses.GetProperty("data").GetString()!);
                var tip = ses.GetProperty("mimeType").GetString()!;

                // Yeni modeller doğrudan WAV, eski modeller ham PCM ("audio/L16;codec=pcm;rate=24000") döndürür
                return tip.StartsWith("audio/L16", StringComparison.OrdinalIgnoreCase)
                    ? (WavBasligiEkle(veri, OrneklemeHizi(tip)), "audio/wav")
                    : (veri, tip);
            }
        }

        throw new KotaTukendiException("Tüm TTS modellerinin kotası tükendi.");
    }

    // Gemini'nin hata açıklamasını loga yazar (kullanıcıya gösterilmez)
    private async Task HataVarsaLogla(HttpResponseMessage yanit, string model)
    {
        if (!yanit.IsSuccessStatusCode)
            _gunluk.LogError("Gemini {Model} hata döndürdü ({Durum}): {Govde}",
                model, (int)yanit.StatusCode, await yanit.Content.ReadAsStringAsync());
    }

    // candidates[0].content.parts[0]; yanıt boşsa (sessizlik, güvenlik filtresi) null
    private static JsonElement? IlkParca(JsonElement json)
    {
        if (!json.TryGetProperty("candidates", out var adaylar) || adaylar.GetArrayLength() == 0)
            return null;
        if (!adaylar[0].TryGetProperty("content", out var icerik) ||
            !icerik.TryGetProperty("parts", out var parcalar) || parcalar.GetArrayLength() == 0)
            return null;
        return parcalar[0];
    }

    private static int OrneklemeHizi(string icerikTuru)
    {
        var rate = icerikTuru.Split(';').Select(p => p.Trim())
            .FirstOrDefault(p => p.StartsWith("rate=", StringComparison.OrdinalIgnoreCase));
        return rate != null && int.TryParse(rate[5..], out var hiz) ? hiz : 24000;
    }

    // Ham PCM'in (16 bit, mono) başına 44 baytlık WAV başlığı ekler; tarayıcı ancak böyle çalabilir
    private static byte[] WavBasligiEkle(byte[] pcm, int orneklemeHizi)
    {
        const short kanal = 1, bit = 16;
        using var ms = new MemoryStream(44 + pcm.Length);
        using var w = new BinaryWriter(ms);
        w.Write("RIFF"u8); w.Write(36 + pcm.Length); w.Write("WAVE"u8);
        w.Write("fmt "u8); w.Write(16); w.Write((short)1); w.Write(kanal);
        w.Write(orneklemeHizi); w.Write(orneklemeHizi * kanal * bit / 8); w.Write((short)(kanal * bit / 8)); w.Write(bit);
        w.Write("data"u8); w.Write(pcm.Length); w.Write(pcm);
        return ms.ToArray();
    }
}
