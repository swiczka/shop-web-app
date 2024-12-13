using Microsoft.EntityFrameworkCore;
using shop_web_app.Data;
using shop_web_app.Interfaces;
using shop_web_app.Models;

namespace shop_web_app.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) 
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Order>> GetAllUserOrders(string userId)
        {
            var orders = await _context.Orders
                .Include(v => v.OrderItems)
                    .ThenInclude(a => a.Variant)
                    .ThenInclude(b => b.Photos)
                .Include(c => c.OrderItems)
                    .ThenInclude(d => d.Variant)
                    .ThenInclude(e => e.Product)
                .Where(u => u.OrdererId == userId).ToListAsync();
            return orders;
        }

        public async Task<List<Product>> GetAllUserProducts(string userId)
        {
            var products = await _context.Products
                .Include(v => v.ProductVariants)
                    .ThenInclude(p => p.Photos)
                .Where(u => u.AuthorId == userId).ToListAsync();
            return products;
        }
    }
}
