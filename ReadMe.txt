Özet Proje Geliþtirme Aþamalarý:

1) Record'dan miras alan Entity ve DbContext'ten miras alan sýnýflarýn oluþturulmasý ve
DbContext'ten miras alan sýnýfta DbContextOptions tipinde parameter alan constructor'ýn yazýlmasý.
2) Service'ten miras alan abstract (soyut) ve concrete (somut) Service sýnýflarýnýn oluþturulmasý,
soyut ve somut sýnýf içerisinde projenin DbContext'ten miras alan sýnýfýnýn constructor'da enjekte edilmesi 
ve ihtiyaca göre base Service abstract class'ýndaki methodlarýn override edilmesi.
3) appsettings.json ve appsetting.Development.json dosyalarýna connection string yazýlmasý.
4) Program.cs IoC Container'da builder'ýn Services'larýna AddDbContext methodu ile projenin DbContext'ten miras
alan sýnýfýnýn connection string'i builder'ýn Configuration özelliðinin GetConnectionString methodu
üzerinden appsettings.json ve appsettings.Development.json dosyalarýnda tanýmlanan ad ile dönülerek eklenmesi.
5) Tools -> NuGet Package Manager -> Package Manager Console açýldýktan sonra DbContext'ten miras alan sýnýfýn olduðu
proje seçilir, daha sonra Uygulama veya Restful Servis projesi de fare ile sað týklanýp baþlangýç projesi olarak ayarlanýr.
Son olarak Package Manager Console üzerinden sýrasýyla add-migration v1 (v1 yerine herhangi tekil bir isim verilebilir) ve
update-database komutlarý çalýþtýrýlarak projemizin DbSet ve Entity'leri üzerinden veritabaný oluþturulur.
6) Program.cs IoC Container'da builder'ýn Services'larýna AddScoped methodu ile proje ile ilgili servislerin
sol tarafta base abstract tipleri (soyut), sað tarafta da base abstract tiplerinden miras alan 
concrete tipleri (somut) belirtilerek eklenmesi.
7) Ýlgili servislerin ilgili controller'lara base abstract tipleri kullanýlarak constructor üzerinden enjekte edilmesi 
ve controller action'larýnýn CRUD iþlemleri için ilgili entity'ler kullanýlarak oluþturulmasý.
8) Her bir action için içerisindeki model (entity) üzerinden view oluþturulmasý.
9) _Layout.cshtml'deki menüye oluþturulan controller'larýn Index (listeleme) action'larý için link eklenmesi.

Proje Referanslarýnýn Eklenmesi:
1) MVC -> AppCore ve Business Project References
2) Business -> AppCore Project Reference

NuGet Paketleri:
1) AppCore -> Microsoft.EntityFrameworkCore.SqlServer
2) Business -> Microsoft.EntityFrameworkCore.Tools
3) Uygulama (MVC) veya Restful Servis (WebApi) -> Microsoft.EntityFrameworkCore.Design

Bu Projenin Katmanlarý:
3) Uygulama (MVC) veya Restful Servis (WebApi) Katmaný
2) Business Katmaný (Service (Repository), Entity (Model entity üzerinden geniþletilerek oluþturulacak), DbContext)
1) AppCore Katmaný

Diðer Örnek Proje Katmanlarý:
4) Uygulama (MVC) veya Restful Servis (WebApi) Katmaný
3) Business Katmaný (Service (Entity <-> Model dönüþümleri için), Model)
2) DataAccess Katmaný (Repository, Entity, DbContext)
1) AppCore Katmaný