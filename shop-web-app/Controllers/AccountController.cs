using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shop_web_app.Data;
using shop_web_app.Interfaces;
using shop_web_app.Models;
using shop_web_app.OtherModels;
using shop_web_app.Repository;
using shop_web_app.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Text.RegularExpressions;

namespace shop_web_app.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IPasswordValidator<AppUser> _passwordValidator;
        private readonly IDashboardRepository _dashboardRepository;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
                                    IUserRepository userRepository,
                                    IAddressRepository addressRepository,
                                    IPasswordValidator<AppUser> passwordValidator,
                                    IDashboardRepository dashboardRepository) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _passwordValidator = passwordValidator;
            _dashboardRepository = dashboardRepository;
        }

        public async Task<IActionResult> Manager(string? email, string? id, string? role)
        {
            if (!User.IsInRole("admin"))
                return RedirectToAction("Error", "Error", new { code = 403});

            ManagerViewModel vm = new ManagerViewModel();
            List<UserWithRole> usersWithRoles = new List<UserWithRole>();

            List<AppUser> users = new List<AppUser>();

            if (email == null && id == null && role == null)
            {
                users = await _userRepository.GetUsers();
            }
            else
            {
                users = await _userRepository.GetUsersByEmailAndId(email, id, role);
            }
            var roles = new[] { "admin", "employee", "customer" };

            foreach (var user in users)
            {
                foreach (var _role in roles)
                {
                    if (await _userManager.IsInRoleAsync(user, _role))
                    {
                        usersWithRoles.Add(new UserWithRole() { User = user, Role = _role });
                        break;
                    }
                    else if(_role == "customer") //no role was detected
                    {
                        usersWithRoles.Add(new UserWithRole() { User = user, Role = null });
                    }
                }
            }

            vm.appUsers = usersWithRoles;

            return View(vm);
        }

        //view available only for admins and employees. customers can use dashboard only
        public async Task<IActionResult> Details(string id)
        {
            if(!(User.IsInRole("admin")))
            {
                return RedirectToAction("Error", "Error", new { code = 403 });
            }

            var user = await _userRepository.GetUserWithAddress(id);
            String role = "";

            if (await _userManager.IsInRoleAsync(user, "admin"))
                role = "admin";
            else if (await _userManager.IsInRoleAsync(user, "employee"))
                role = "employee";
            else if (await _userManager.IsInRoleAsync(user, "customer"))
                role = "customer";

            AccountInfoViewModel viewModel = new AccountInfoViewModel()
            {
                AppUser = user,
                Orders = await _dashboardRepository.GetAllUserOrders(id),
                CurrentRole = role
            };

            viewModel.Orders.Reverse();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(AccountInfoViewModel vm)
        {
            var user = await _userManager.FindByIdAsync(vm.UserId);
            var currentUser = await _userManager.GetUserAsync(User);


            if (currentUser == null || user == null || !(User.IsInRole("admin")) || currentUser.Id == user.Id )
            {
                return RedirectToAction("Error", "Error", new { code = 403 });
            }

            if (vm.NewRole == null || user == null || !(new[] { "admin", "customer", "employee" }).Contains(vm.NewRole))
                return RedirectToAction("Error", "Error", new { code = 400 });

            if(vm.CurrentRole != null) await _userManager.RemoveFromRoleAsync(user, vm.CurrentRole);
            await _userManager.AddToRoleAsync(user, vm.NewRole);

            return RedirectToAction("Manager");
        }

        public async Task<IActionResult> Edit()
        {
            string userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                RedirectToAction("Login", "Account");
            }

            AppUser user = await _userRepository.GetUserWithAddress(userId);

            EditAccountViewModel vm = new EditAccountViewModel()
            {
                AppUser = user,
                Name = user.Name,
                Surname = user.Surname,
            };

            return View(vm); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAccountViewModel vm)
        {
            string userId = _userManager.GetUserId(User);
            if (userId == null || userId != vm.AppUser.Id)
            {
                return RedirectToAction("Error", "Error", new { code = 401 });
            }

            AppUser user = await _userRepository.GetUserWithAddress(userId);
            
            if (!ModelState.IsValid)
            {
                vm.AppUser = user;
                return View(vm);
            }

            if(vm.Street != null || vm.City != null || vm.PostalCode != null || vm.Voivodship != null)
            {
                if(vm.Street != null && vm.City != null && vm.PostalCode != null && vm.Voivodship != null)
                {
                    //user wants to add new address
                    string postalCodePattern = @"^\d{2}-\d{3}$";
                    if (!Regex.IsMatch(vm.PostalCode, postalCodePattern))
                    {
                        TempData["Error"] = "Kod pocztowy musi być w formacie XX-XXX";
                        vm.AppUser = user;
                        return View(vm);
                    }

                    if(user.Address != null)
                    {
                        user.Address.City = vm.City;
                        user.Address.PostalCode = vm.PostalCode;
                        user.Address.Street = vm.Street;
                        user.Address.Voivodship = vm.Voivodship.Value;

                        _addressRepository.Update(user.Address);
                    }
                    else
                    {
                        Address address = new Address()
                        {
                            City = vm.City,
                            PostalCode = vm.PostalCode,
                            Street = vm.Street,
                            Voivodship = vm.Voivodship.Value
                        };

                        _addressRepository.Add(address);
                        user.Address = address;
                    } 
                }
                else
                {
                    //user gave incomplete address info
                    TempData["Error"] = "Wypełnij albo wszytkie pola adresu, albo żadne";
                    vm.AppUser = user;
                    return View(vm);
                }
            }

            if (!string.IsNullOrEmpty(vm.Password) || !string.IsNullOrEmpty(vm.ConfirmPassword) || !string.IsNullOrEmpty(vm.OldPassword))
            {
                if (string.IsNullOrEmpty(vm.Password) || string.IsNullOrEmpty(vm.ConfirmPassword) || string.IsNullOrEmpty(vm.OldPassword))
                {
                    TempData["Error"] = "Wprowadź wszystkie pola hasła.";
                    vm.AppUser = user;
                    return View(vm);
                }

                if (vm.Password != vm.ConfirmPassword)
                {
                    TempData["Error"] = "Hasła muszą być identyczne.";
                    vm.AppUser = user;
                    return View(vm);
                }

                var passwordChangeResult = await _userManager.ChangePasswordAsync(user, vm.OldPassword, vm.Password);
                if (!passwordChangeResult.Succeeded)
                {
                    TempData["Error"] = string.Join(" ", passwordChangeResult.Errors.Select(e => e.Description));
                    vm.AppUser = user;
                    return View(vm);
                }
            }

            user.Name = vm.Name;
            user.Surname = vm.Surname;
            user.Gender = vm.Gender;

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Dashboard");


        }

        public IActionResult Login()
        {
            //response is there for keeping form data from vanishing when reloading page
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if(passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Niepoprawne hasło, spróbuj ponownie.";
                return View(loginVM);
            }
            TempData["Error"] = "Nie znaleziono konta o takim adresie e-mail.";
            return View(loginVM);
        }

        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            response.Gender = null;
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if(!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user != null)
            {
                TempData["Error"] = "Konto o podanym adresie e-mail już istnieje.";
                return View(registerVM);
            }

            var tempUser = new AppUser();
            var result = await _passwordValidator.ValidateAsync(_userManager, tempUser, registerVM.Password);

            if (!result.Succeeded)
            {
                TempData["Error"] = "Hasło musi się składać z co najmniej 6 znaków, zawierać co najmniej jedną dużą literę, co najmniej jedną małą literę, co najmniej jedną cyfrę oraz co najmniej jeden znak specjalny.";
                return View(registerVM);
            }

            var newUser = new AppUser()
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.Email.Split('@')[0],
                Email = registerVM.Email,
                Gender = registerVM.Gender
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.Customer);
            }
            else
            {
                var errors = string.Join(", ", newUserResponse.Errors.Select(e => e.Description));
                TempData["Error"] = errors;
                return View(registerVM);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
