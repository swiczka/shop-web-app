using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shop_web_app.Interfaces;
using shop_web_app.Models;
using shop_web_app.ViewModels;

namespace shop_web_app.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(IUserRepository userRepository, UserManager<AppUser> userManager) 
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Create()
        {
            List<CartItem> cartItems = await _userRepository.GetCartItems(_userManager.GetUserId(User));
            AppUser user = await _userManager.GetUserAsync(User);

            CreateOrderViewModel vm = new CreateOrderViewModel()
            {
                CartItems = cartItems,
                AppUser = user
            };
            return View(vm);
        }
    }
}
