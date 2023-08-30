using ECommerce.BLL.Abstract;
using ECommerce.BLL.AbstractServices;
using ECommerce.BLL.Concrete;
using ECommerce.BLL.Services;
using ECommerce.DAL.Context;
using ECommerce.Entity.Base;
using ECommerce.IOC.Container;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

//Database Service
builder.Services.AddDbContext<ECommerceContext>();

#region SamplesForServiceIOC
//builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));

//categoryService specific entity
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<IProductService, ProductService>(); 
#endregion

//Services
ServiceIOC.ServiceConfigure(builder.Services);

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});


app.Run();
