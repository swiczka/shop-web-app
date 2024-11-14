using Microsoft.AspNetCore.Mvc;
using shop_web_app.Data;

namespace shop_web_app.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context) 
        {
            _context = context;
        }

        public IActionResult Index() 
        { 
            return View();
        }
    }
}
