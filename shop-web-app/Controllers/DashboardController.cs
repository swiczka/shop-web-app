using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shop_web_app.Data;
using shop_web_app.Interfaces;
using shop_web_app.Models;
using shop_web_app.ViewModels;

namespace shop_web_app.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IDashboardRepository dashboardRepository, UserManager<AppUser> userManager) 
        {
            _dashboardRepository = dashboardRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index() 
        {
            string userId = _userManager.GetUserId(User);
            
            if (userId == null) 
            {
                return RedirectToAction("Login", "Account");
            }

            DashboardViewModel viewModel = new DashboardViewModel()
            {
                AppUser = await _userManager.GetUserAsync(User),
                Orders = await _dashboardRepository.GetAllUserOrders(userId)
            };

            if(User.IsInRole("admin") || User.IsInRole("employee"))
            {
                viewModel.Products = await _dashboardRepository.GetAllUserProducts(userId);
            }

            return View(viewModel);
        }
    }
}
