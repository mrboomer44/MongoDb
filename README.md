# MongoDb Kurumsal Web Projesi

Bu proje, **ASP.NET Core 8.0 MVC** ve **MongoDB** kullanılarak geliştirilmiş, dinamik bir kurumsal web sitesi ve yönetim (admin) paneli uygulamasıdır. Proje, modern web standartlarına uygun olarak N-Katmanlı mimari yapısına benzer bir servis yaklaşımıyla inşa edilmiştir.

## 🚀 Kullanılan Teknolojiler

*   **Framework:** .NET 8.0 (ASP.NET Core MVC)
*   **Veritabanı:** MongoDB (NoSQL)
*   **Nesne Eşleme (Mapping):** AutoMapper
*   **Kimlik Doğrulama:** Cookie Authentication (Çerez Bazlı Oturum Yönetimi)
*   **Bağımlılık Enjeksiyonu (DI):** ASP.NET Core Built-in DI Container
*   **Frontend:** HTML5, CSS3, Bootstrap, jQuery (Admin ve UI temaları)

## 📌 Özellikler

### 🌐 Kullanıcı Arayüzü (UI)
*   Ana Sayfa, Hakkımızda, Hizmetler/Ürünler, Sıkça Sorulan Sorular, Referanslar (Testimonial), Video Hikayeleri bölümleri.
*   Dinamik View Component yapısı ile modüler ve hızlı sayfa yüklemeleri.
*   E-Bülten abonelik sistemi.

### 🛡️ Yönetim Paneli (Admin)
*   Gelişmiş, şifre korumalı admin girişi ve güvenli oturum yönetimi (Hatalı girişlerde 15 dk / 24 saat IP banlama ve rate limiting özellikleri).
*   **Hakkımızda (AboutList, AboutSection vb.) Yönetimi:** Metinleri ve listeleri güncelleyebilme.
*   **Ürün/Hizmet (Product/Feature) Yönetimi:** Portföyde sergilenen içeriklerin eklenip çıkarılması.
*   **SSS (Faq) Yönetimi:** Kullanıcıların sıkça sorduğu soruların yönetimi.
*   **Sipariş (Order) Yönetimi:** Gelen sipariş kayıtlarının takibi.
*   **Sosyal Medya (SocialMedia) Yönetimi:** Alt kısımda (footer) bulunan sosyal medya linklerinin dinamik kontrolü.
*   **Abonelik (Subscribe) Yönetimi:** E-Bültene kayıt olan kişilerin listesi.

## 📂 Proje Mimarisi

*   **Controllers:** Gelen istekleri (HTTP Requests) karşılayıp uygun View'lara veya iş kurallarına yönlendiren katman.
*   **Services:** İş mantığının (Business Logic) yer aldığı katman. MongoDB koleksiyonları ile Controller'lar arasında köprü kurar.
*   **Entities:** Veritabanı tablolarına (Koleksiyonlara) denk gelen ana model sınıfları (BSON ID yapılarıyla).
*   **Dtos (Data Transfer Objects):** View'lar ile servisler arasında sadece ihtiyaç duyulan verilerin taşınmasını sağlayan hafif objeler.
*   **ViewComponents:** UI kısmındaki modüler parçaları (Footer, Navbar, Dinamik Listeler) yöneten bileşenler.
*   **Settings:** MongoDB bağlantı ayarlarının (`appsettings.json` üzerinden) yakalandığı konfigürasyon sınıfları.

## ⚙️ Kurulum ve Çalıştırma

1.  Bu depoyu (repository) yerel bilgisayarınıza klonlayın:
    ```bash
    git clone https://github.com/KULLANICI_ADINIZ/MongoDb.git
    ```
2.  Bilgisayarınızda **MongoDB**'nin kurulu ve arka planda çalışıyor (`localhost:27017`) olduğundan emin olun.
3.  Proje dizinine gidin:
    ```bash
    cd MongoDb/MongoDb
    ```
4.  Gerekli kütüphaneleri (NuGet paketlerini) yükleyin ve projeyi derleyin:
    ```bash
    dotnet restore
    dotnet build
    ```
5.  Projeyi çalıştırın:
    ```bash
    dotnet run
    ```
6.  Tarayıcınızdan `http://localhost:5189` veya konsolda belirtilen porta giderek siteye erişebilirsiniz.
7.  Admin paneline erişmek için URL sonuna `/Admin/Index` ekleyerek giriş ekranına ulaşabilirsiniz.

## 🤝 Katkıda Bulunma

Projeye katkıda bulunmak isterseniz, lütfen bir Pull Request gönderin veya karşılaştığınız sorunlar için bir Issue açın. Katkılarınız her zaman değerlidir!

## 📜 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakabilirsiniz.
