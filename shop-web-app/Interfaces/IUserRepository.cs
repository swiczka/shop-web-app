using shop_web_app.Models;

namespace shop_web_app.Interfaces
{
    public interface IUserRepository
    {
        Task<List<CartItem>> GetCartItems(string userId);
        Task<List<AppUser>> GetUsers();
        Task<List<AppUser>> GetUsersByEmailAndId(string? email, string? id, string? role);
        Task<AppUser> GetUserWithAddress(string userId);
    }
}
