using shop_web_app.Models;

namespace shop_web_app.Interfaces
{
    public interface IUserRepository
    {
        Task<List<CartItem>> GetCartItems(string userId);
    }
}
