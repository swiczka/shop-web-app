using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models;
using shop_web_app.ViewModels;
using System.Collections.Generic;

namespace shop_web_app.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderController(IUserRepository userRepository, UserManager<AppUser> userManager, IOrderRepository orderRepository, IProductRepository productRepository) 
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Create()
        {
            List<CartItem> cartItems = await _userRepository.GetCartItems(_userManager.GetUserId(User));
            AppUser user = await _userManager.Users
                .Include(p => p.Address)
                .FirstOrDefaultAsync(i => i.Id == _userManager.GetUserId(User));

            CreateOrderViewModel vm = new CreateOrderViewModel()
            {
                Name = user.Name,
                Surname = user.Surname,
                CartItems = cartItems,
                AppUser = user
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel vm)
        {
            List <CartItem> cartItems = await _userRepository.GetCartItems(_userManager.GetUserId(User));
            AppUser user = await _userManager.Users
                .Include(p => p.Address)
                .FirstOrDefaultAsync(i => i.Id == _userManager.GetUserId(User));
            if (user == null)
            {
                TempData["Error"] = "Sesja wygasła";
                return RedirectToAction("Login", "Account");
            }

            vm.AppUser = user;
            vm.CartItems = cartItems;

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            else
            {
                List<OrderItem> orderItems = new List<OrderItem>();

                foreach(var item in vm.CartItems)
                {
                    if(item.Variant.Product.Category != Category.Shoes)
                    {
                        if (item.Quantity <= item.Variant.InternationalSizeQuantity.FirstOrDefault(q => q.Size == item.InternationalSize.Value).Quantity)
                        {
                            item.Variant.InternationalSizeQuantity.FirstOrDefault(q => q.Size == item.InternationalSize.Value).Quantity -= item.Quantity;
                        }
                        else
                        {
                            TempData["Error"] = "Produkt nie jest już dostępny w tej ilości";
                            return View(vm);
                        }
                        OrderItem newItem = new OrderItem()
                        {
                            Variant = item.Variant,
                            InternationalSize = item.InternationalSize,
                            Quantity = item.Quantity,
                            TotalPrice = item.Variant.Product.Price * item.Quantity
                        };
                        orderItems.Add(newItem);
                    }
                    else
                    {
                        if (item.Quantity <= item.Variant.ShoeSizeQuantity.FirstOrDefault(q => q.Size == item.ShoeSize.Value).Quantity)
                        {
                            item.Variant.ShoeSizeQuantity.FirstOrDefault(q => q.Size == item.ShoeSize.Value).Quantity -= item.Quantity;
                        }
                        else
                        {
                            TempData["Error"] = "Produkt nie jest już dostępny w tej ilości";
                            return View(vm);
                        }
                        OrderItem newItem = new OrderItem()
                        {
                            Variant = item.Variant,
                            ShoeSize = item.ShoeSize,
                            Quantity = item.Quantity,
                            TotalPrice = item.Variant.Product.Price * item.Quantity
                        };
                        orderItems.Add(newItem);
                    }
                    _productRepository.Save();
                }

                if (vm.SaveAddress)
                {
                    user.Address = vm.DeliveryAddress;
                }
                if (!vm.DifferentAddress)
                {
                    vm.BillingAddress = vm.DeliveryAddress;
                }

                Order newOrder = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderItems = orderItems,
                    Orderer = user,
                    DeliveryAddress = vm.DeliveryAddress,
                    BillingAddress = vm.BillingAddress,
                    Status = OrderStatus.OrderPlaced
                };

                _orderRepository.Add(newOrder);
                _orderRepository.Save();
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
