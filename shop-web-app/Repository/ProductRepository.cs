using Microsoft.EntityFrameworkCore;
using shop_web_app.Data;
using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models;
using shop_web_app.Models.SizeQuantity;

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

        public async Task<ProductMaterial> GetProductMaterialByIdAsync(int id)
        {
            return await _context.ProductMaterials.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductVariant> GetProductVariantByIdAsync(int id)
        {
            return await _context.ProductVariants.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<VariantColor>> GetVariantColorsByVariantIdAsync(int variantId)
        {
            return await _context.VariantColors.Where(c => c.VariantId == variantId).ToListAsync();
        }

        public async Task<IEnumerable<InternationalSizeQuantity>> GetInternationalSQByVariantIdAsync(int variantId)
        {
            return await _context.InternationalSizeQuantity.Where(c => c.VariantId == variantId).ToListAsync();
        }

        public async Task<IEnumerable<ShoeSizeQuantity>> GetShoeSQByVariantIdAsync(int variantId)
        {
            return await _context.ShoeSizeQuantity.Where(c => c.VariantId == variantId).ToListAsync();
        }

        public bool DeleteShoeSizeQuantity(ShoeSizeQuantity sq)
        {
            _context.ShoeSizeQuantity.Remove(sq);
            return Save();
        }

        public bool DeleteProductVariant(ProductVariant variant)
        {
            _context.ProductVariants.Remove(variant);
            return Save();
        }

        public bool DeleteInternationalSizeQuantity(InternationalSizeQuantity sq)
        {
            _context.InternationalSizeQuantity.Remove(sq);
            return Save();
        }

        public bool DeleteVariantColor(VariantColor color)
        {
            _context.VariantColors.Remove(color);
            return Save();
        }

        public bool DeleteProductMaterial(ProductMaterial material)
        {
            _context.ProductMaterials.Remove(material);
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

        public async Task<IEnumerable<Product>> GetAllActive()
        {
            return await _context.Products
                .Include(p => p.ProductVariants)
                    .ThenInclude(v => v.Photos)
                .Include(p => p.ProductMaterials)
                .Where(p => p.IsActive == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetFiltered(ClothingGender? gender, decimal? priceFrom, decimal? priceTo, SubCategory? category, string? sortBy, string? isActive)
        {
            var query = _context.Products.AsQueryable();

            if(gender != null)
            {
                query = query.Where(p => p.Gender == gender || p.Gender == ClothingGender.U);
            }
            if(priceFrom != null || priceTo != null)
            {
                if (priceTo == null)
                    priceTo = 9999999;
                if (priceFrom == null)
                    priceFrom = 0;

                query = query.Where(p => p.Price >= priceFrom &&  p.Price <= priceTo);
            }
            if(category != null)
            {
                query = query.Where(p => p.SubCategory == category);
            }

            if(sortBy != null)
            {
                switch (sortBy)
                {
                    case "priceAsc":
                        query = query.OrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        query = query.OrderByDescending(p => p.Price);
                        break;
                    case "alphaAsc":
                        query = query.OrderBy(p => p.Name);
                        break;
                    case "alphaDesc":
                        query = query.OrderByDescending(p => p.Name);
                        break;
                    default:
                        break;
                }
            }

            if(isActive != null)
            {
                switch (isActive)
                {
                    case "activeOnly":
                        query = query.Where(p => p.IsActive == true);
                        break;
                    case "all":
                        break;
                    case "inactiveOnly":
                        query = query.Where(p => p.IsActive == false);
                        break;
                    default:
                        break;
                }
            }

            return await query
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