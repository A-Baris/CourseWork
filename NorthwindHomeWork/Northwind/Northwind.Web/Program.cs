using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Northwind.BLL.Repositories;
using Northwind.BLL.Services;
using Northwind.DAL.Models.Context;
using NorthwindAPI.Repositories;
using NorthwindAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//Dbcontext
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Scoped
builder.Services.AddScoped<ISupplierRepository, SupplierService>();
builder.Services.AddScoped<IProductRepository, ProductService>();
builder.Services.AddScoped<ICategoryRepository, CategoryService>();
builder.Services.AddScoped<IOrderRepository, OrderService>();

//Disturbed Session Configure
builder.Services.AddDistributedMemoryCache();

//Session
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "product_cart";
    options.IdleTimeout = TimeSpan.FromMinutes(5);
});

//CORS

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CORS", cors =>
//    {
//        cors.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("https://localhost:7020");
//    });
//});



var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("CORS");
app.MapControllers();
app.UseSession();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=home}/{action=Index}/{id?}");

app.Run();