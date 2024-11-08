using Microsoft.EntityFrameworkCore;
using shop_web_app.Data;
using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models;

namespace shop_web_app.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public bool Add(Product product)
        {
            _context.Products.Add(product);
            return Save();
        }

        public bool Delete(Product product)
        {
            _context.Products.Remove(product);
            return Save();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products
                .Include(p => p.ProductVariants)
                    .ThenInclude(v => v.Photos)
                .Include(p => p.ProductMaterials)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductVariants)
                    .ThenInclude(v => v.Photos)
                .Include(p => p.ProductVariants)
                    .ThenInclude(v => v.VariantColors)
                .Include(p => p.ProductVariants)
                    .ThenInclude(v => v.InternationalSizeQuantity)
                .Include(p => p.ProductVariants)
                    .ThenInclude(v => v.ShoeSizeQuantity)
                .Include(p => p.ProductMaterials)
                .FirstOrDefaultAsync(p => p.Id == id); 
        }


        public async Task<IEnumerable<Product>> GetByNameAsync(string name)
        {
            return await _context.Products.Where(c =>  c.Name.Contains(name)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Product product)
        {
            _context.Update(product);
            return Save();
        }

        public async Task<Product> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Products
                .Include(p => p.ProductVariants)
                    .ThenInclude(v => v.Photos)
                .Include(p => p.ProductVariants)
                    .ThenInclude(v => v.VariantColors)
                .Include(p => p.ProductVariants)
                    .ThenInclude(v => v.InternationalSizeQuantity)
                .Include(p => p.ProductVariants)
                    .ThenInclude(v => v.ShoeSizeQuantity)
                .Include(p => p.ProductMaterials)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}