using shop_web_app.Models;

namespace shop_web_app.Interfaces
{
    public interface IOrderRepository
    {
        bool Add(Order order);
        bool Update(Order order);
        bool Delete(Order order);
        bool Save();
        Task<List<Order>> GetOrdersByUser(string userId);
        Task<Order> GetOrderById(int id);
        Task<Order> GetOnlyOrderById(int id);
        Task<List<Order>> GetAllOrdersAsync();
        Task<List<Order>> GetOrdersFilteredAsync(string email, int id);
    }
}
