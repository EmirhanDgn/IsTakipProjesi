# İş Takip Uygulaması

Bu proje, kullanıcıların iş takibi yapabileceği, görevler oluşturabileceği ve görevlerin durumlarını yönetebileceği bir web uygulamasıdır. Uygulama ASP.NET Core 8, Entity Framework Core ve MSSQL kullanılarak geliştirilmiştir. 

## Teknolojiler

- **ASP.NET Core 8**: Modern ve yüksek performanslı bir web frameworkü.
- **Entity Framework Core**: .NET için nesne-ilişkisel haritalama (ORM) frameworkü.
- **MSSQL**: Microsoft SQL Server veritabanı yönetim sistemi.
- **Bootstrap 4**: Modern ve duyarlı (responsive) web tasarımı için CSS frameworkü.
- **JavaScript**: Dinamik ve etkileşimli web sayfaları oluşturmak için kullanılan programlama dili.

## Özellikler

- Kullanıcı girişi ve çıkışı
- Yeni iş ekleme
- İş listesi görüntüleme
- İş detaylarını görüntüleme ve düzenleme
- Görevlere yorum ekleme
- Görevlere üye ekleme
- Görev durumunu değiştirme
- SQL Injection filtreleme

## Proje Yapısı

Proje, aşağıdaki gibi katmanlı mimari prensiplerine uygun olarak yapılandırılmıştır:

IsTakipProjesi
- ├── Controllers
- │ ├── AuthController.cs
- │ ├── HomeController.cs
- │ ├── IsTakibiController.cs
- │ └── UsersController.cs
- ├── Data
- │ └── AppDbContext.cs
- ├── Filters
- │ ├── SessionCheckFilter.cs
- │ ├── SkipSessionCheckAttribute.cs
- │ └── SqlInjectionFilter.cs
- ├── Migrations
- │ └── <MigrationsFiles>
- ├── Models
- │ ├── ErrorViewModel.cs
- │ ├── TaskComment.cs
- │ ├── TaskList.cs
- │ ├── TaskMember.cs
- │ └── User.cs
- ├── Views
- │ └── <ViewFiles>
- ├── appsettings.json
- └── Program.cs

## Kullanım
- Giriş
- Giriş yaparak mevcut işleri görüntüleyebilir, yeni işler ekleyebilir ve mevcut işleri yönetebilirsiniz.

## Yeni İş Ekleme
- "Yeni İş Ekle" sayfasına giderek yeni bir iş ekleyin.
- İş adı, açıklama, başlangıç ve bitiş tarihleri, önem derecesi gibi bilgileri doldurun.
- Üye ekleyerek görevi kiminle birlikte yapacağınızı belirleyin.

## İş Listesi
- "İş Takip Listesi" sayfasında mevcut işleri görüntüleyin.
- İşlerin durumlarını ve üyelerini kontrol edin.
- İlgili işin detaylarını görmek için "Detaylar" butonuna tıklayın.

## İş Detayları
- İş detayları sayfasında işin tüm bilgilerini görüntüleyin.
- İşin durumunu değiştirin, yorum ekleyin ve üyeleri düzenleyin.
