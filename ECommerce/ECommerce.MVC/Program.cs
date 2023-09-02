using ECommerce.BLL.Abstracts;
using ECommerce.BLL.AbstractServices;
using ECommerce.BLL.Concretes;
using ECommerce.BLL.Services;
using ECommerce.DAL.Context;
using ECommerce.IOC.Container;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//MVC
builder.Services.AddControllersWithViews();




//Database Service
builder.Services.AddDbContext<EcommerceContext>();








ServiceIOC.ServiceConfigure(builder.Services);



var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();


//EndPoint


app.MapControllerRoute(
    name: "admin",
     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}"
    );


app.Run();
