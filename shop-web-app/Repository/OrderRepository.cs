using Microsoft.EntityFrameworkCore;
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

        public async Task<Order> GetOrderById(int id)
        {
            var order = _context.Orders
                .Include(v => v.OrderItems)
                    .ThenInclude(a => a.Variant)
                    .ThenInclude(b => b.Photos)
                .Include(c => c.OrderItems)
                    .ThenInclude(d => d.Variant)
                    .ThenInclude(e => e.Product)
                .Include(a => a.BillingAddress)
                .Include(a => a.DeliveryAddress)
                .FirstOrDefault(o => o.Id == id);
            return order;
        }

        public async Task<Order> GetOnlyOrderById(int id)
        {
            var order = _context.Orders
                .FirstOrDefault(o => o.Id == id);
            return order;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(a => a.Orderer)
                .Include(v => v.OrderItems)
                    .ThenInclude(a => a.Variant)
                    .ThenInclude(b => b.Photos)
                .Include(c => c.OrderItems)
                    .ThenInclude(d => d.Variant)
                    .ThenInclude(e => e.Product)
                .OrderByDescending(a => a.OrderDate)
                .ToListAsync();
            return orders;
        }

        public async Task<List<Order>> GetOrdersFilteredAsync(string email, int id)
        {
            var query = _context.Orders.AsQueryable();

            if(email != null)
            {
                query = query.Where(p => p.Orderer.Email.Contains(email));
            }
            if(id != -1)
            {
                query = query.Where(p => p.Id == id);
            }

            return await query
                .Include(a => a.Orderer)
                .Include(v => v.OrderItems)
                    .ThenInclude(a => a.Variant)
                    .ThenInclude(b => b.Photos)
                .Include(c => c.OrderItems)
                    .ThenInclude(d => d.Variant)
                    .ThenInclude(e => e.Product)
                .OrderByDescending(a => a.OrderDate)
                .ToListAsync();
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
