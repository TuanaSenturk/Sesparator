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
        await seslendir(cevap.mesaj);
        // cevap.onayGerekli true ise onay/iptal akışı burada devreye girecek
    }

    async function seslendir(metin) {
        durumYaz('Yanıt seslendiriliyor...');
        const yanit = await fetch('/api/ses/sese-cevir', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ metin })
        });
        if (oturumDustuMu(yanit)) return;
        if (!yanit.ok) {
            balonEkle(`Sesli yanıt verilemedi: ${await hataMesaji(yanit)}`, 'asistan');
            return;
        }

        const adres = URL.createObjectURL(await yanit.blob());
        const oynatici = new Audio(adres);
        oynatici.onended = () => URL.revokeObjectURL(adres);
        try {
            await oynatici.play();
        } catch {
            URL.revokeObjectURL(adres);   // tarayıcı otomatik oynatmayı engellediyse
        }
    }

    mikrofon.addEventListener('click', () => {
        if (kaydedici) {
            kaydedici.stop();
        } else if (!mesgul) {
            kaydiBaslat();
        }
    });

    form.addEventListener('submit', async e => {
        e.preventDefault();
        const metin = kutu.value.trim();
        if (!metin || mesgul) return;

        kutu.value = '';
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
    });
})();
