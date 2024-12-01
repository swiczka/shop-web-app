using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_web_app.Data;
using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models;
using shop_web_app.OtherModels;
using shop_web_app.Repository;
using shop_web_app.ViewModels;

namespace shop_web_app.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _userRepository;

        public CartController(ICartRepository cartRepository, UserManager<AppUser> userManager, IUserRepository userRepository) 
        {
            _cartRepository = cartRepository;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);

            if (userId != null)
            {
                List<CartItem> cartItems = await _userRepository.GetCartItems(userId);
                return View(cartItems);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CartItemAddModel cartItem)
        {
            var userId = _userManager.GetUserId(User);

            if(userId != null)
            {
                InternationalSize internationalSize;
                ShoeSize shoeSize = ShoeSize.Size35;
                bool isShoe = false;
                List<CartItem> cartItems = await _userRepository.GetCartItems(userId);
                
                if(Enum.TryParse<InternationalSize>(cartItem.Size, out internationalSize))
                {
                    isShoe = false;
                    foreach (CartItem item in cartItems)
                    {
                        if (item.Variant.Id == cartItem.ProductVariantId &&
                        item.InternationalSize.Value == internationalSize)
                        {
                            item.Quantity++;
                            return Json(new { success = true, message = "Item added to cart." });
                        }
                    }
                        
                }
                else if(Enum.TryParse<ShoeSize>(cartItem.Size, out shoeSize))
                {
                    isShoe = true;
                    foreach (CartItem item in cartItems)
                    {
                        if (item.Variant.Id == cartItem.ProductVariantId &&
                        item.ShoeSize.Value == shoeSize)
                        {
                            item.Quantity++;
                            return Json(new { success = true, message = "Item added to cart." });
                        }
                    }
                }

                CartItem newCartItem;

                if (isShoe)
                { 
                    newCartItem = new CartItem()
                    {
                        VariantId = cartItem.ProductVariantId,
                        ShoeSize = shoeSize,
                        AppUserId = userId,
                        Quantity = 1
                    };
                    _cartRepository.Add(newCartItem);
                    return Json(new { success = true, message = "Item added to cart." });          
                }
                else
                {
                    newCartItem = new CartItem()
                    {
                        VariantId = cartItem.ProductVariantId,
                        InternationalSize = internationalSize,
                        AppUserId = userId,
                        Quantity = 1
                    };
                    _cartRepository.Add(newCartItem);
                    return Json(new { success = true, message = "Item added to cart." });
                }
                
            }
            return Unauthorized();
            
            
        }


        public async Task<IActionResult> Delete(int id)
        {
            CartItem cartItem = await _cartRepository.GetCartItemByIdAsync(id);
            _cartRepository.Delete(cartItem);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateQuantity(int cartItemId, int newQuantity)
        {
            CartItem cartItem = await _cartRepository.GetCartItemByIdAsync(cartItemId);

            if (cartItem != null)
            {
                cartItem.Quantity = newQuantity;
                _cartRepository.Update(cartItem);
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}
