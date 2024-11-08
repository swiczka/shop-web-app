using shop_web_app.Models;
using shop_web_app.Models.SizeQuantity;

namespace shop_web_app.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<ProductMaterial> GetProductMaterialByIdAsync(int id);
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Product>> GetByNameAsync(string name);
        bool Add(Product product);
        bool Update(Product product);
        bool DeleteProductMaterial(ProductMaterial material);
        bool Delete(Product product);
        bool Save();
        Task<ProductVariant> GetProductVariantByIdAsync(int id);
        bool DeleteProductVariant(ProductVariant variant);
        bool DeleteVariantColor(VariantColor color);
        bool DeleteInternationalSizeQuantity(InternationalSizeQuantity sq);
        bool DeleteShoeSizeQuantity(ShoeSizeQuantity sq);
        Task<IEnumerable<VariantColor>> GetVariantColorsByVariantIdAsync(int variantId);
        Task<IEnumerable<InternationalSizeQuantity>> GetInternationalSQByVariantIdAsync(int variantId);
        Task<IEnumerable<ShoeSizeQuantity>> GetShoeSQByVariantIdAsync(int variantId);
    }
}
