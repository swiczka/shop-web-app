using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models;
using shop_web_app.ViewModels;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace shop_web_app.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;

        public OrderController(IUserRepository userRepository,
                                UserManager<AppUser> userManager,
                                IOrderRepository orderRepository,
                                IProductRepository productRepository,
                                ICartRepository cartRepository) 
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public async Task<IActionResult> Create()
        {
            var userId = _userManager.GetUserId(User);

            if(userId == null)
            {
                TempData["Error"] = "Sesja wygasła";
                return RedirectToAction("Login", "Account");
            }

            List<CartItem> cartItems = await _userRepository.GetCartItems(userId);
    
            AppUser user = await _userRepository.GetUserWithAddress(userId);

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
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                TempData["Error"] = "Sesja wygasła";
                return RedirectToAction("Login", "Account");
            }

            List <CartItem> cartItems = await _userRepository.GetCartItems(userId);
            AppUser user = await _userRepository.GetUserWithAddress(userId);

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
                    _cartRepository.Delete(item);
                    _cartRepository.Save();
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

        public async Task<IActionResult> Details(int id)
        {
            AppUser user = await _userManager.GetUserAsync(User);
            Order order = await _orderRepository.GetOrderById(id);

            if (user == null)
            {
                TempData["Error"] = "Sesja wygasła";
                return RedirectToAction("Login", "Account");
            }
            if (order == null)
            {
                return RedirectToAction("Error", "Error", new { code = 404 });
            }

            if(user.Id != order.OrdererId)
            {
                if(!(User.IsInRole("admin") || User.IsInRole("employee")))
                    return RedirectToAction("Error", "Error", new { code = 403 });
            }

            OrderDetailsViewModel vm = new OrderDetailsViewModel() 
            {
                Order = order,
                OrderStatus = order.Status
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeOrderStatus(OrderDetailsViewModel vm)
        {
            if (!(User.IsInRole("admin") || User.IsInRole("employee")))
            {
                return RedirectToAction("Error", "Error", new { code = 403 });
            }

            if (vm.OrderId != null)
            {
                //additional GetOnlyOrderById method to save query size
                Order order = await _orderRepository.GetOnlyOrderById((int)vm.OrderId);
                if (vm.OrderStatus != null)
                {
                    order.Status = (OrderStatus)vm.OrderStatus;
                    _orderRepository.Update(order);
                }
            }
            try
            {
                return RedirectToAction("Details", "Order", new { id = (int)vm.OrderId });
            }
            catch 
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Index(string? email, string? id)
        {
            if (!(User.IsInRole("admin") || User.IsInRole("employee")))
            {
                return RedirectToAction("Error", "Error", new { code = 403 });
            }
            if(email == null && id == null)
            {
                var orders = await _orderRepository.GetAllOrdersAsync();
                return View(orders);
            }
            try
            {
                int idInt = Int32.Parse(id);
                var ordersF = await _orderRepository.GetOrdersFilteredAsync(email, idInt);
                return View(ordersF);
            }
            catch
            {
                var ordersF = await _orderRepository.GetOrdersFilteredAsync(email, -1);
                return View(ordersF);
            }

            
        }
    }
}
