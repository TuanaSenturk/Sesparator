// Sohbet sayfası akışı:
// mikrofon -> /api/ses/metne-cevir -> kullanıcı balonu -> asistan yanıtı -> /api/ses/sese-cevir -> sesi çal
(() => {
    const govde = document.getElementById('sohbetGovde');
    const form = document.getElementById('sohbetFormu');
    const kutu = document.getElementById('mesajKutusu');
    const mikrofon = document.getElementById('mikrofonButonu');
    const gonder = document.getElementById('gonderButonu');
    const durum = document.getElementById('sohbetDurumu');

    // Komutlar kısa; unutulan kayıt 20 saniyede kendiliğinden durur
    const EN_UZUN_KAYIT_MS = 20000;

    let kaydedici = null;
    let parcalar = [];
    let zamanlayici = null;
    let mesgul = false;
    let onayKutusu = null;
    let calanSes = null;      // şu an çalan asistan sesi (Audio)
    let sesSirasi = 0;        // her yeni seslendirmede ya da durdurmada artar

    function balonEkle(metin, kimden) {
        const mesaj = document.createElement('div');
        mesaj.className = `mesaj ${kimden}`;

        const balon = document.createElement('div');
        balon.className = 'balon';
        balon.textContent = metin;   // innerHTML değil: kullanıcı metni HTML olarak yorumlanmasın

        const saat = document.createElement('div');
        saat.className = 'saat';
        saat.textContent = new Date().toLocaleTimeString('tr-TR', { hour: '2-digit', minute: '2-digit' });

        mesaj.append(balon, saat);
        govde.append(mesaj);
        govde.scrollTop = govde.scrollHeight;
    }

    function durumYaz(metin) {
        durum.textContent = metin ?? '';
    }

    function mesgulYap(deger) {
        mesgul = deger;
        mikrofon.disabled = deger;
        gonder.disabled = deger;
        kutu.disabled = deger;
    }

    // API hata döndürürse { mesaj: "..." } içindeki metni al
    async function hataMesaji(yanit) {
        try {
            return (await yanit.json()).mesaj ?? 'Bir hata oluştu.';
        } catch {
            return 'Bir hata oluştu.';
        }
    }

    // Oturum düştüyse API giriş sayfasına yönlendirir; sayfayı yenileyip girişe gönderiyoruz
    function oturumDustuMu(yanit) {
        if (yanit.redirected || yanit.status === 401) {
            location.reload();
            return true;
        }
        return false;
    }

    async function kaydiBaslat() {
        sesiDurdur();   // asistanın sesi kayda girmesin
        if (!navigator.mediaDevices?.getUserMedia || !window.MediaRecorder) {
            balonEkle('Tarayıcınız ses kaydını desteklemiyor. Mesajınızı yazarak gönderebilirsiniz.', 'asistan');
            return;
        }

        let akis;
        try {
            akis = await navigator.mediaDevices.getUserMedia({ audio: true });
        } catch {
            balonEkle('Mikrofon izni verilmedi. Tarayıcı ayarlarından izin verebilirsiniz.', 'asistan');
            return;
        }

        // Chrome/Edge/Firefox webm, Safari mp4 kaydeder
        const tur = ['audio/webm;codecs=opus', 'audio/ogg;codecs=opus', 'audio/mp4']
            .find(t => MediaRecorder.isTypeSupported(t));

        parcalar = [];
        kaydedici = new MediaRecorder(akis, tur ? { mimeType: tur } : undefined);
        kaydedici.ondataavailable = e => {
            if (e.data.size > 0) parcalar.push(e.data);
        };
        kaydedici.onstop = async () => {
            akis.getTracks().forEach(t => t.stop());   // mikrofon simgesi tarayıcıdan kalksın
            clearTimeout(zamanlayici);
            mikrofon.classList.remove('kayitta');

            const ses = new Blob(parcalar, { type: kaydedici.mimeType });
            kaydedici = null;
            await sesiIsle(ses);
        };

        kaydedici.start();
        mikrofon.classList.add('kayitta');
        mikrofon.title = 'Bitirmek için tekrar basın';
        gonder.disabled = true;
        kutu.disabled = true;
        durumYaz('Dinliyorum... Bitirmek için mikrofona tekrar basın.');
        zamanlayici = setTimeout(() => kaydedici?.stop(), EN_UZUN_KAYIT_MS);
    }

    async function sesiIsle(ses) {
        mesgulYap(true);
        mikrofon.title = 'Konuşmak için basın';
        try {
            durumYaz('Ses yazıya çevriliyor...');
            const veri = new FormData();
            veri.append('ses', ses, 'kayit');

            const yanit = await fetch('/api/ses/metne-cevir', { method: 'POST', body: veri });
            if (oturumDustuMu(yanit)) return;
            if (!yanit.ok) {
                balonEkle(await hataMesaji(yanit), 'asistan');
                return;
            }

            const { metin } = await yanit.json();
            balonEkle(metin, 'kullanici');
            await yanitla(metin);
        } catch {
            balonEkle('Sunucuya ulaşılamadı. Bağlantınızı kontrol edin.', 'asistan');
        } finally {
            mesgulYap(false);
            durumYaz('');
        }
    }

    async function yanitla(metin) {
        onayDugmeleriniKaldir();
        durumYaz('Asistan düşünüyor...');
        const yanit = await fetch('/api/asistan/mesaj', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ metin })
        });
        if (oturumDustuMu(yanit)) return;
        if (!yanit.ok) {
            balonEkle(await hataMesaji(yanit), 'asistan');
            return;
    }

        const cevap = await yanit.json();
        balonEkle(cevap.mesaj, 'asistan');
        if (cevap.onayGerekli) onayDugmeleriEkle();
        await seslendir(cevap.mesaj);
    }

    // Onay bekleyen transfer için Onayla / Vazgeç düğmeleri.
    // Düğmeler "evet" / "vazgeç" metnini gönderir; sunucu sesle ya da yazıyla verilen cevapla aynı şekilde işler.
    function onayDugmeleriEkle() {
        onayDugmeleriniKaldir();

        onayKutusu = document.createElement('div');
        onayKutusu.className = 'onay-kutusu d-inline-flex gap-2 mb-3';
        onayKutusu.append(
            onayDugmesi('Onayla', 'btn-success', 'fa-check', 'evet'),
            onayDugmesi('Vazgeç', 'btn-outline-secondary', 'fa-times', 'vazgeç')
        );
        govde.append(onayKutusu);
        govde.scrollTop = govde.scrollHeight;
    }

    function onayDugmesi(yazi, renk, ikon, gonderilecekMetin) {
        const dugme = document.createElement('button');
        dugme.type = 'button';
        dugme.className = `btn btn-sm ${renk}`;
        const simge = document.createElement('i');
        simge.className = `fas ${ikon} me-1`;
        dugme.append(simge, yazi);
        dugme.addEventListener('click', () => komutGonder(gonderilecekMetin));
        return dugme;
    }

    // Yeni bir mesaj gönderilince eski düğmeler kalkar (aynı işlem iki kez onaylanmasın)
    function onayDugmeleriniKaldir() {
        onayKutusu?.remove();
        onayKutusu = null;
    }

    // Çalan sesi durdurur. sesSirasi artırıldığı için yolda olan eski seslendirme isteği de geçersiz olur.
    function sesiDurdur() {
        sesSirasi++;
        if (calanSes) {
            calanSes.pause();
            URL.revokeObjectURL(calanSes.src);
            calanSes = null;
        }
    }

    async function seslendir(metin) {
        sesiDurdur();
        const benimSiram = sesSirasi;

        durumYaz('Yanıt seslendiriliyor...');
        const yanit = await fetch('/api/ses/sese-cevir', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ metin })
        });
        if (benimSiram !== sesSirasi) return;   // bu arada yeni bir ses istendi ya da ses durduruldu
        if (oturumDustuMu(yanit)) return;
        if (!yanit.ok) {
            balonEkle(`Sesli yanıt verilemedi: ${await hataMesaji(yanit)}`, 'asistan');
            return;
        }

        const ses = await yanit.blob();
        if (benimSiram !== sesSirasi) return;

        const adres = URL.createObjectURL(ses);
        const oynatici = new Audio(adres);
        oynatici.onended = () => {
            URL.revokeObjectURL(adres);
            if (calanSes === oynatici) calanSes = null;
        };
        calanSes = oynatici;
        try {
            await oynatici.play();
        } catch {
            URL.revokeObjectURL(adres);   // tarayıcı otomatik oynatmayı engellediyse
            if (calanSes === oynatici) calanSes = null;
        }
    }

    mikrofon.addEventListener('click', () => {
        if (kaydedici) {
            kaydedici.stop();
        } else if (!mesgul) {
            kaydiBaslat();
        }
    });

    form.addEventListener('submit', e => {
        e.preventDefault();
        const metin = kutu.value.trim();
        if (!metin || mesgul) return;

        kutu.value = '';
        komutGonder(metin);
    });

    // Yazılı mesaj ve Onayla/Vazgeç düğmeleri bu fonksiyonla gönderilir
    async function komutGonder(metin) {
        if (mesgul || kaydedici) return;

        sesiDurdur();   // kullanıcı yeni komut verdi: asistan sözünü kessin
        balonEkle(metin, 'kullanici');
        mesgulYap(true);
        try {
            await yanitla(metin);
        } catch {
            balonEkle('Sunucuya ulaşılamadı. Bağlantınızı kontrol edin.', 'asistan');
        } finally {
            mesgulYap(false);
            durumYaz('');
            kutu.focus();
        }
    }
})();
