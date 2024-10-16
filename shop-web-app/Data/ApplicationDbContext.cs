using Microsoft.EntityFrameworkCore;
using shop_web_app.Models;
using shop_web_app.Models.Clothing;
using shop_web_app.Models.SizeQuantity;

namespace shop_web_app.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {   
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ClothingItem<InternationalSizeQuantity, ClothingType>> Clothes { get; set; }
    }
}

