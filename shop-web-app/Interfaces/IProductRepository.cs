using shop_web_app.Models;

namespace shop_web_app.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetByNameAsync(string name);
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(Product product);
        bool Save();
    }
}
