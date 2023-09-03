using ECommerce.Entity.Base;
using ECommerce.Entity.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;

namespace ECommerce.DAL.Context
{
    public class EcommerceContext : IdentityDbContext
    {
     



        //Dbset
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-KUQ9PNH;database=ECommerceDB;uid=sa;pwd=1234;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        
            base.OnModelCreating(builder);
        }


       

        public override int SaveChanges()
        {

            //veri yeni eklenirken

            //veri güncellenirken 

            var modifierEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added);

            try
            {
               
                foreach (var item in modifierEntries)
                {
                    var entityRepository = item.Entity as BaseClass;
                    if (item.State == EntityState.Modified)
                    {
                        entityRepository.UpdatedDate = DateTime.Now;
                        entityRepository.UpdatedIpAddress = IpAddressFound();
                        entityRepository.UpdatedComputerName = Environment.MachineName;

                    }
                    else if (item.State == EntityState.Added)
                    {
                      
                        entityRepository.CreatedDate = DateTime.Now;
                        entityRepository.CreatedIpAddress = IpAddressFound();
                        entityRepository.CreatedComputerName=Environment.MachineName;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


            return base.SaveChanges();
        }
        public string IpAddressFound() // tekrar edeceğimiz için method içerisine aldım.
        {
            string ipAddress = "";
            //Ağa bağlı olan cihaz adı
            string hostname = Dns.GetHostName();
            //Cihaz adıyla ilişkili Ip adresleri diziye aktarma
            IPAddress[] addresses = Dns.GetHostAddresses(hostname);
            //Aktarılan Ip adreslerinden IPv4 adresini bulmak için döngü kullanıyoruz
            foreach (IPAddress address in addresses)
            {
                //Ip adreslerinin Ipv4 adresi olup olmadığını kontrol eder. Örnek:Eğer IPv6 ise onu pas geçer
                if (address.AddressFamily == AddressFamily.InterNetwork)  
                {
                    ipAddress = address.ToString(); //string değişkene Ipv4 adresini aktardık
                    break; // ilk bulunan adresten sonra artık döngüyü sonlandırıyoruz
                }
            }
            return ipAddress;
        
        }
    }
}
