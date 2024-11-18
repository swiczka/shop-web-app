using shop_web_app.Models;

namespace shop_web_app.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Order>> GetAllUserOrders();
        Task<List<Product>> GetAllUserProducts();
    }
}
