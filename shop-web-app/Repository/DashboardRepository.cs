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

        public async Task<List<Order>> GetAllUserOrders()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllUserProducts()
        {
            throw new NotImplementedException();
        }
    }
}
