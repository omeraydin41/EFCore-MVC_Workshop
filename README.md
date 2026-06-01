# StoreFlow (KULLANILAN TÜM METHODLAR (EntitityFrameworkKullanılanMethodlar.txt) DOSYASINDA MEVCUTTUR) TURKISH/ENGLISH DESCRIPTION
StoreFlow projesinin temel amacı, Entity Framework Core teknolojisini baştan sona öğrenmek ve gerçek bir uygulama üzerinde mümkün olduğunca fazla Entity Framework Core metodunu kullanarak deneyim kazanmaktır.

Proje geliştirilirken yalnızca temel CRUD işlemleriyle sınırlı kalınmamış; veri ekleme, güncelleme, silme, filtreleme, sıralama, gruplama, ilişkilendirme, istatistiksel hesaplamalar ve performans optimizasyonu gibi birçok farklı senaryo uygulanmıştır. 
Böylece Entity Framework Core'un sunduğu metotların çalışma mantığı, kullanım amaçları ve gerçek projelerdeki kullanım alanları detaylı şekilde incelenmiştir.

Bu proje aynı zamanda bir yazılımcı adayının ORM (Object Relational Mapping) mantığını anlaması, 
LINQ sorgularında yetkinlik kazanması, veritabanı ilişkilerini yönetebilmesi ve ASP.NET Core MVC mimarisi içerisinde Entity Framework Core'u etkin şekilde kullanabilmesi amacıyla geliştirilmiştir.

Projenin ikincil hedefleri arasında modern bir yönetim paneli geliştirmek, Partial View yapısını kullanarak daha modüler bir arayüz oluşturmak, dashboard ekranları hazırlamak ve veri odaklı raporlama sistemleri geliştirmek bulunmaktadır.
Ancak projenin ana odağı, Entity Framework Core'un sunduğu özellikleri kapsamlı şekilde öğrenmek ve uygulamaktır.

## Kullanılan Teknolojiler

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* LINQ
* Code First Yaklaşımı
* Migration Yapısı
* Razor View Engine
* Partial View Yapısı
* Bootstrap
* JavaScript
* Chart.js

## Entity Framework Core Çalışmaları
Bu proje geliştirilirken Entity Framework Core'un çok sayıda metodu gerçek kullanım senaryolarında uygulanmıştır.

## MVC ve Katmanlı Yapı Deneyimi
Proje boyunca ASP.NET Core MVC mimarisi kullanılmıştır. Controller, Model ve View katmanları birbirinden ayrılarak sürdürülebilir ve okunabilir bir yapı oluşturulmuştur.
Her modül için ayrı controller yapıları geliştirilmiş, veri akışı ViewModel'ler üzerinden yönetilmiş ve kod tekrarını azaltmak amacıyla ortak bileşenler oluşturulmuştur.

## Partial View Kullanımı
Projede kullanıcı arayüzünü daha modüler hale getirmek amacıyla Partial View yapısından yoğun şekilde yararlanılmıştır.

Bu sayede:
  * Menü bileşenleri
  * Dashboard kartları
  * Bildirim alanları
  * Görev listeleri
  * Mesaj bileşenleri
  * Ortak sayfa bölümleri
tek bir noktadan yönetilebilir hale getirilmiştir. Böylece hem kod tekrarının önüne geçilmiş hem de bakım maliyeti azaltılmıştır.

## Dashboard ve Raporlama Ekranları
StoreFlow yalnızca veri giriş ekranlarından oluşan bir uygulama değildir. Yönetim panelinde çeşitli istatistiksel bilgiler ve raporlamalar yer almaktadır.

Dashboard ekranlarında:
  * Toplam ürün sayıları
  * Sipariş istatistikleri
  * Müşteri analizleri
  * Şehirlere göre müşteri dağılımları
  * Sipariş durum raporları
  * Günlük ve genel performans göstergeleri
gibi veriler Entity Framework Core sorguları kullanılarak dinamik şekilde üretilmiştir.

## Kullanıcı Arayüzü Çalışmaları
Proje geliştirilirken yalnızca backend tarafına değil kullanıcı deneyimine de önem verilmiştir.

Bu kapsamda:
  * Responsive tasarım
  * Yönetim paneli görünümü
  * Kart yapıları
  * Tablo ekranları
  * Grafikler ve raporlar
  * Kullanıcı dostu form tasarımları
oluşturularak uygulamanın gerçek bir kurumsal panel deneyimi sunması hedeflenmiştir.

## Bu Proje ile Kazanılan Yetkinlikler

* Entity Framework Core veri erişim mantığı
* LINQ sorguları oluşturma
* İlişkisel veri tabanı tasarımı
* ASP.NET Core MVC mimarisi
* Dashboard geliştirme
* Partial View kullanımı
* Veri analizi ve raporlama
* SQL Server yönetimi
* Code First ve Migration süreçleri
* Kurumsal yönetim paneli geliştirme

## Sonuç
StoreFlow, bir mağaza yönetim sistemi geliştirmenin ötesinde, Entity Framework Core'un geniş metot yelpazesini uygulamalı olarak öğrenmek, 
ASP.NET Core MVC mimarisini deneyimlemek, dashboard ve raporlama ekranları oluşturmak ve modern kullanıcı arayüzleri geliştirmek amacıyla hazırlanmış kapsamlı bir portföy projesidir.
Proje sayesinde hem backend hem de frontend tarafında gerçek dünya senaryolarına yakın bir geliştirme deneyimi elde edilmiştir.

DİĞER PROJELERİMDE GÖRÜŞMEK ÜZERE.


///////////////////////////////////////////////////////////////////
# StoreFlow (ALL METHODS USED ARE AVAILABLE IN THE FILE: EntitityFrameworkKullanılanMethodlar.txt)

The primary purpose of the StoreFlow project is to learn Entity Framework Core from start to finish and gain hands-on experience by utilizing as many Entity Framework Core methods as possible within a real-world application.

During the development process, the project was not limited to basic CRUD operations. Various scenarios such as data insertion, updating, deletion, filtering, sorting, grouping, relationship management, statistical calculations, and performance optimization were implemented.

As a result, the working principles, purposes, and practical applications of Entity Framework Core methods were examined in detail through real development scenarios.

This project was also developed to help a software developer candidate understand ORM (Object Relational Mapping) concepts, gain proficiency in LINQ queries, manage database relationships effectively, and utilize Entity Framework Core efficiently within the ASP.NET Core MVC architecture.

Among the secondary objectives of the project were developing a modern administration panel, creating a more modular user interface using the Partial View structure, building dashboard screens, and implementing data-driven reporting systems.

However, the main focus of the project is to comprehensively learn and apply the features provided by Entity Framework Core.

## Technologies Used

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* LINQ
* Code-First Approach
* Migration Structure
* Razor View Engine
* Partial View Structure
* Bootstrap
* JavaScript
* Chart.js

## Entity Framework Core Studies

Throughout the development of this project, a large number of Entity Framework Core methods were implemented in real-world scenarios.

## MVC and Layered Architecture Experience

The project was developed using the ASP.NET Core MVC architecture. Controller, Model, and View layers were separated to create a maintainable and readable structure.

Separate controller structures were developed for each module, data flow was managed through ViewModels, and shared components were created to minimize code duplication.

## Partial View Implementation

The Partial View structure was extensively utilized to create a more modular user interface.

This allowed the following components to be managed from a single location:

* Menu components
* Dashboard cards
* Notification areas
* Task lists
* Message components
* Shared page sections

As a result, code duplication was reduced and maintenance became significantly easier.

## Dashboard and Reporting Screens

StoreFlow is not simply a data-entry application. The administration panel includes various statistical analyses and reporting features.

Dashboard screens dynamically generate data through Entity Framework Core queries, including:

* Total product counts
* Order statistics
* Customer analyses
* Customer distribution by city
* Order status reports
* Daily and overall performance indicators

## User Interface Development

The project focuses not only on backend development but also on user experience.

Within this scope, the following features were implemented:

* Responsive design
* Administration panel interface
* Card-based layouts
* Data table screens
* Charts and reports
* User-friendly form designs

The goal was to provide an experience similar to a real corporate management panel.

## Skills and Competencies Gained Through This Project

* Entity Framework Core data access principles
* LINQ query development
* Relational database design
* ASP.NET Core MVC architecture
* Dashboard development
* Partial View implementation
* Data analysis and reporting
* SQL Server management
* Code-First and Migration processes
* Corporate administration panel development

## Conclusion

StoreFlow is a comprehensive portfolio project designed not only to develop a store management system but also to gain practical experience with the extensive range of Entity Framework Core methods, explore the ASP.NET Core MVC architecture, build dashboard and reporting screens, and develop modern user interfaces.

Through this project, valuable real-world development experience was gained on both the backend and frontend sides of software development.

SEE YOU IN MY OTHER PROJECTS.



