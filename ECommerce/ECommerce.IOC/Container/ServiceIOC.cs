using ECommerce.BLL.Abstracts;
using ECommerce.BLL.AbstractServices;
using ECommerce.BLL.Concretes;
using ECommerce.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.IOC.Container
{
    public class ServiceIOC
    {
        public static void ServiceConfigure(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            //category service
            services.AddScoped<ICategoryService, CategoryService>();

            //product service
            services.AddScoped<IProductService, ProductService>();

            //supplier service
            services.AddScoped<ISupplierService, SupplierService>();
            //order service

            //order detail service
        }



    }
}
