using shop_web_app.Data;
using shop_web_app.Interfaces;
using shop_web_app.Models;

namespace shop_web_app.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public bool Add(Order order)
        {
            _context.Orders.Add(order);
            return Save();
        }

        public bool Delete(Order order)
        {
            _context.Orders.Remove(order);
            return Save();
        }

        public Task<List<Order>> GetOrdersByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(Order order)
        {
            _context.Orders.Update(order);
            return Save();
        }
    }
}
