﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shop_web_app.Data;
using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models;
using shop_web_app.OtherModels;
using shop_web_app.Repository;
using shop_web_app.ViewModels;

namespace shop_web_app.Controllers
{
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<AppUser> _userManager;

        public CartController(ICartRepository cartRepository, UserManager<AppUser> userManager) 
        {
            _cartRepository = cartRepository;
            _userManager = userManager;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CartItemAddModel cartItem)
        {
            var userId = _userManager.GetUserId(User);

            if(userId != null)
            {
                InternationalSize internationalSize;
                ShoeSize shoeSize;
                CartItem newCartItem;

                if (cartItem.Size.Contains("size"))
                {
                    if (Enum.TryParse<ShoeSize>(cartItem.Size, out shoeSize))
                    {
                        newCartItem = new CartItem()
                        {
                            VariantId = cartItem.ProductVariantId,
                            ShoeSize = shoeSize,
                            AppUserId = userId,
                            Quantity = 1,
                            TotalPrice = cartItem.Price
                        };
                        _cartRepository.Add(newCartItem);
                        return Json(new { success = true, message = "Item added to cart." });
                    }
                }
                else
                {
                    if (Enum.TryParse<InternationalSize>(cartItem.Size, out internationalSize))
                    {
                        newCartItem = new CartItem()
                        {
                            VariantId = cartItem.ProductVariantId,
                            InternationalSize = internationalSize,
                            AppUserId = userId,
                            Quantity = 1,
                            TotalPrice = cartItem.Price
                        };
                        _cartRepository.Add(newCartItem);
                        return Json(new { success = true, message = "Item added to cart." });
                    }
                }
                
            }
            return Unauthorized();
            
            
        }
    }
}
