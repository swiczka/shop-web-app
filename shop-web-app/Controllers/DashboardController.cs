using Microsoft.AspNetCore.Mvc;

namespace shop_web_app.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index() 
        { 
            return View();
        }
    }
}
