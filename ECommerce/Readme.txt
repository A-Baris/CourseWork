# ECommerce Project

##	NTier katmanlý mimariye sahip bu projede standart olarak 3 katman dahil edilmiþtir.

### Entity
	veritabanýnda tablo haline gelecek olan nesnelerimiz bu katman içerisinde barýndýrýlacak. 
- Product
- Category

### DAL (Data Access Layer)

Paketler:
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools


- Context: Veritabaný nesnesini temsil etmektedir.


### BLL (Business Logic Layer)

- AbstractRepositories
	- IRepository: Bütün entityler için gerçekleþtirilecek olan eylemleri soyut olarak içeren interface'dir. Bu interface dýþarýdan bir T tipi almalýdýr. Ancak dýþarýdan alýnacak olan bu tip kesinlikle BaseEntity olmalýdýr.

- Concretes
	- BaseRepository: Bu class IRepository interface'i üzerinden implement edilen somut bir class'dýr. Interface içerisinde tanýmlý olan eylemler burada bütün entity'ler için somut olarak oluþturuldu. Bunun mantýðý ise BaseEntity tipinde olan bütün varlýklara uygulanacak olan eylemleri içermesidir. (Create, Read, Update, Delete)

Projemiz içerisinde bazen ayrý bir entity için ayrý bir metot kullanmak isteyebiliriz. (Yukarýdaki CRUD iþlemlerinden hariç) bu durumda o entity'e ait bir kontrat ve o kontrat'a baðlý somut eylemlerin olmasý gerekmektedir. Bu tür iþlemleri IRepository'e baðýmlý olarak Servis þeklinde kullanmamýz gerekmektedir. Aþaðýdaki iþlemleri bahsi yapýlan servisleri içerir...


- AbstractServices
	-ICategoryService: Category ile ilgili temelde yapýalcak olan iþlemler özünde CRUD olarak tanýmlanan iþlemlerdir. Bu yüzden ICategorysErvice içerisinde standart CRUD eylemleri yer almaktadýr.

- Services
	- CategoryService: ICategoryService'den miras alýnarak içerdiði metotlar implement edilir. Yapýlacak olan eylemler standart eylemler olduðu için constructor'da IRepository'e Tip "Category" gönderilmiþtir. Bu durumda bu service IRepositoryService'e baðýmlýdýr. Yapýlacak iþlemler sabit. Ancak bu servis içerisinde sadece Category classýna ait iþlemler de özelleþtirebilinir. (Örn. En çok satýþ gerçekleþtirilen Category'ler gibi vs...) bahsi yapýlan baðýmlýklar en sonunda UI katmaný içerisinde bulunan servis arakatmanýnda (Middleware) dahil edilerek kullanýma alýnmalýdýr. (Bknz: MVC.program.cs)

	
### IOC
	bu katman Service içerisinde kullanýlacak olan Repository'leri ve Concrete sýnýflarý dahil eden bir static metot barýndýrýkmaktadýr. Bu metot Program.cs içerisinde arakatmada modüler olarak dahil edilmiþtir. Amacýmýz; proje dahilinde kullanmak istediðimiz service'leri tek bir çatý altýnda toplayarak dilediðimizde deðiþtirme imkanýna sahip olabilmemiz içindir.

### Presentation Layer (UI)



## Admin Template
https://github.com/ColorlibHQ/AdminLTE/releases