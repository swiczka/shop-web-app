using shop_web_app.Models;

namespace shop_web_app.Interfaces
{
    public interface ICartRepository
    {
        bool Add(CartItem item);
        bool Update(CartItem item);
        bool Delete(CartItem item);
        bool Save();
        Task<List<CartItem>> GetCartItemsByUser(string userId);
    }
}
