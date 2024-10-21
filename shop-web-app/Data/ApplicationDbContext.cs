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
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<InternationalSizeQuantity> InternationalSizeQuantities { get; set; }
        public DbSet<ShoeSizeQuantity> ShoeSizeQuantities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<VariantColor> VariantColors { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }

    }
}

