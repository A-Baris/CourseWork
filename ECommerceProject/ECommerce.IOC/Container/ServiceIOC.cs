using ECommerce.BLL.Abstract;
using ECommerce.BLL.AbstractServices;
using ECommerce.BLL.Concrete;
using ECommerce.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.IOC.Container
{
    public class ServiceIOC
    {
        public static void ServiceConfigure(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();

        }
    }
}
