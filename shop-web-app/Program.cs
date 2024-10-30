using shop_web_app.Models.Clothing;
using shop_web_app.Enums;
using shop_web_app.Models.SizeQuantity;
using Microsoft.AspNetCore.Mvc;
using shop_web_app.Data;
using Microsoft.EntityFrameworkCore;
using shop_web_app.Models;
using shop_web_app.Interfaces;
using shop_web_app.Repository;
using shop_web_app.Helpers;
using shop_web_app.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<BlobStorageService, BlobStorageService>();
builder.Services.Configure<AzureBlobStorageSettings>(builder.Configuration.GetSection("BlobStorageSettings"));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    //Seed.SeedUsersAndRolesAsync(app);
    Seed.SeedData(app);
} 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
