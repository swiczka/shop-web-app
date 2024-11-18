using Microsoft.AspNetCore.Mvc;
using shop_web_app.Data;
using shop_web_app.Interfaces;

namespace shop_web_app.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository) 
        {
            _dashboardRepository = dashboardRepository;
        }

        public IActionResult Index() 
        { 
            return View();
        }
    }
}
