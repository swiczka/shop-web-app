using shop_web_app.Models.Clothing;
using shop_web_app.Enums;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

Console.WriteLine("Hej");
ShoeClothing shoe = new ShoeClothing();
shoe.Size = ShoeSize.Size42_5;
Console.WriteLine(ShoeSize.Size40.ToFriendlyString());
Console.WriteLine(EnumExtensions.ToFriendlyString(shoe.Size));

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
