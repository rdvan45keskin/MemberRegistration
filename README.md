# 🧾 Member Registration System (C# .NET)

Bu proje, **C# .NET** ile geliştirilmiş bir **Üye Kayıt Sistemi** uygulamasıdır.  
Projenin amacı, kullanıcıların kayıt olurken **T.C. Kimlik Numarası doğrulamasını** yapmak ve temel katmanlı mimariyle çalışmayı öğrenmektir.
Bu projeyi c# kursunda oluşturdum.

---

## 📂 Proje Yapısı

- **DevFramework.Core** → Altyapı ve temel sınıflar  
- **MemberRegistration.Business** → İş katmanı (business logic)  
- **MemberRegistration.ConsoleUI** → Konsol arayüzü  
- **MemberRegistration.DataAccess** → Veritabanı işlemleri (Entity Framework)  
- **MemberRegistration.Entities** → Varlık (entity) sınıfları  
- **MemberRegistration.MvcWebUI** → Web arayüzü (ASP.NET MVC)

---
📌 Amaç
- Katmanlı mimariyi öğrenmek
- Servis entegrasyonu (SOAP/WCF) uygulamak
- Gerçek hayat senaryosuna uygun bir üye kayıt sistemi geliştirmek
---

## ⚙️ Kullanılan Teknolojiler

- **C# .NET Framework**  
- **ASP.NET MVC**  
- **Entity Framework**  
- **Katmanlı Mimari**  
- **SOAP Servisleri (WCF)**  

---

## 🌐 T.C. Kimlik Doğrulama

Projede, **Nüfus ve Vatandaşlık İşleri Genel Müdürlüğü (NVİ) KPSPublic SOAP servisi** kullanılarak T.C. kimlik numarası doğrulaması yapılmaktadır.  

`App.config` veya `Web.config` içerisinde WCF ayarları şu şekilde yapılmıştır:

```xml
<system.serviceModel>
  <bindings>
    <basicHttpBinding>
      <binding name="KPSPublicSoap">
        <security mode="Transport" />
      </binding>
      <binding name="KPSPublicSoap1" />
    </basicHttpBinding>
  </bindings>
  <client>
    <endpoint address="https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx"
              binding="basicHttpBinding"
              bindingConfiguration="KPSPublicSoap"
              contract="KpsServiceReference.KPSPublicSoap"
              name="KPSPublicSoap" />
  </client>
</system.serviceModel>
```

🚀 Çalıştırma

1. Projeyi klonlayın:
```bash
git clone https://github.com/kullanici-adiniz/MemberRegistration.git
```
2. MemberRegistration.sln dosyasını Visual Studio ile açın.
3. Gerekli NuGet paketlerini yükleyin.
4. MemberRegistration.MvcWebUI veya MemberRegistration.ConsoleUI projelerinden birini başlatın.







