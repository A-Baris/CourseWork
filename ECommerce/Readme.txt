# ECommerce Project

##	NTier katmanl� mimariye sahip bu projede standart olarak 3 katman dahil edilmi�tir.

### Entity
	veritaban�nda tablo haline gelecek olan nesnelerimiz bu katman i�erisinde bar�nd�r�lacak. 
- Product
- Category

### DAL (Data Access Layer)

Paketler:
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools


- Context: Veritaban� nesnesini temsil etmektedir.


### BLL (Business Logic Layer)

- AbstractRepositories
	- IRepository: B�t�n entityler i�in ger�ekle�tirilecek olan eylemleri soyut olarak i�eren interface'dir. Bu interface d��ar�dan bir T tipi almal�d�r. Ancak d��ar�dan al�nacak olan bu tip kesinlikle BaseEntity olmal�d�r.

- Concretes
	- BaseRepository: Bu class IRepository interface'i �zerinden implement edilen somut bir class'd�r. Interface i�erisinde tan�ml� olan eylemler burada b�t�n entity'ler i�in somut olarak olu�turuldu. Bunun mant��� ise BaseEntity tipinde olan b�t�n varl�klara uygulanacak olan eylemleri i�ermesidir. (Create, Read, Update, Delete)

Projemiz i�erisinde bazen ayr� bir entity i�in ayr� bir metot kullanmak isteyebiliriz. (Yukar�daki CRUD i�lemlerinden hari�) bu durumda o entity'e ait bir kontrat ve o kontrat'a ba�l� somut eylemlerin olmas� gerekmektedir. Bu t�r i�lemleri IRepository'e ba��ml� olarak Servis �eklinde kullanmam�z gerekmektedir. A�a��daki i�lemleri bahsi yap�lan servisleri i�erir...


- AbstractServices
	-ICategoryService: Category ile ilgili temelde yap�alcak olan i�lemler �z�nde CRUD olarak tan�mlanan i�lemlerdir. Bu y�zden ICategorysErvice i�erisinde standart CRUD eylemleri yer almaktad�r.

- Services
	- CategoryService: ICategoryService'den miras al�narak i�erdi�i metotlar implement edilir. Yap�lacak olan eylemler standart eylemler oldu�u i�in constructor'da IRepository'e Tip "Category" g�nderilmi�tir. Bu durumda bu service IRepositoryService'e ba��ml�d�r. Yap�lacak i�lemler sabit. Ancak bu servis i�erisinde sadece Category class�na ait i�lemler de �zelle�tirebilinir. (�rn. En �ok sat�� ger�ekle�tirilen Category'ler gibi vs...) bahsi yap�lan ba��ml�klar en sonunda UI katman� i�erisinde bulunan servis arakatman�nda (Middleware) dahil edilerek kullan�ma al�nmal�d�r. (Bknz: MVC.program.cs)

	
### IOC
	bu katman Service i�erisinde kullan�lacak olan Repository'leri ve Concrete s�n�flar� dahil eden bir static metot bar�nd�r�kmaktad�r. Bu metot Program.cs i�erisinde arakatmada mod�ler olarak dahil edilmi�tir. Amac�m�z; proje dahilinde kullanmak istedi�imiz service'leri tek bir �at� alt�nda toplayarak diledi�imizde de�i�tirme imkan�na sahip olabilmemiz i�indir.

### Presentation Layer (UI)



## Admin Template
https://github.com/ColorlibHQ/AdminLTE/releases