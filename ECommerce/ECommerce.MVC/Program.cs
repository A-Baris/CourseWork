using ECommerce.BLL.Abstracts;
using ECommerce.BLL.AbstractServices;
using ECommerce.BLL.Concretes;
using ECommerce.BLL.Services;
using ECommerce.DAL.Context;
using ECommerce.Entity.Entity;
using ECommerce.IOC.Container;
using Microsoft.AspNetCore.Identity;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//MVC
builder.Services.AddControllersWithViews();




//Database Service
builder.Services.AddDbContext<EcommerceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//identity

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<EcommerceContext>();

builder.Services.Configure<IdentityOptions>(x =>
{
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireDigit = false;
    x.Password.RequiredLength = 6;
    x.Password.RequireLowercase = false;
    x.Password.RequireUppercase = false;
});






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
