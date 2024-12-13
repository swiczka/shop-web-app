using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shop_web_app.Models;
using shop_web_app.Models.Clothing;
using shop_web_app.Models.SizeQuantity;

namespace shop_web_app.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser> //any custom app roles should be put next to AppUser argument
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {   
            
        }
        public DbSet<AppUser> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<InternationalSizeQuantity> InternationalSizeQuantity { get; set; }
        public DbSet<ShoeSizeQuantity> ShoeSizeQuantity { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<VariantColor> VariantColors { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja relacji CartItem -> AppUser
            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.AppUser)
                .WithMany(u => u.CartItems)
                .HasForeignKey(c => c.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);  // Zamiast Cascade użyj Restrict
            // Możesz także skonfigurować inne relacje, jeżeli masz problem z innymi tabelami

            modelBuilder.Entity<Order>()
                .HasOne(o => o.DeliveryAddress)
                .WithMany()
                .HasForeignKey(o => o.DeliveryAddressId)
                .OnDelete(DeleteBehavior.Restrict); // Wyłącza usuwanie kaskadowe

            modelBuilder.Entity<Order>()
                .HasOne(o => o.BillingAddress)
                .WithMany()
                .HasForeignKey(o => o.BillingAddressId)
                .OnDelete(DeleteBehavior.Restrict); // Wyłącza usuwanie kaskadowe
       
        }
    }
}

