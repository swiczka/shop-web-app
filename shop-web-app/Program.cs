using shop_web_app.Models.Clothing;
using shop_web_app.Enums;
using shop_web_app.Models.SizeQuantity;
using Microsoft.AspNetCore.Mvc;
using shop_web_app.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    Seed.SeedUsersAndRolesAsync(app);
}

//ShoeClothing shoe = new ShoeClothing();
//shoe.SizeQuantity.Add
//    (
//    new ShoeSizeQuantity { Size = ShoeSize.Size42_5, Quantity = 1 }
//    );
//shoe.Description = "Najwy¿szej jakoœci materia³y specjalnie dla polaka";
//shoe.Name = "Mokasyny moj¿esza";
//shoe.Gender = ClothingGender.M;
//shoe.Price = 100.99m;
//shoe.Colors.Add(Color.White);
//shoe.Colors.Add(Color.Black);
//shoe.Materials = new List<Material> { Material.Cotton, Material.Plastic };
//shoe.Type = ShoeType.Loafers;

//foreach(var element in shoe.SizeQuantity)
//{
//    Console.WriteLine(element.Size.ToFriendlyString() + ", " + element.Quantity);
//}

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
