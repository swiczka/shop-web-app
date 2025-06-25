using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.FileProviders;
using shop_web_app.Data;
using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models;
using shop_web_app.Models.SizeQuantity;
using shop_web_app.Services;
using shop_web_app.ViewModels;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace shop_web_app.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly BlobStorageService _blobService;
        private readonly UserManager<AppUser> _userManager;

        public ProductController(IProductRepository productRepository, BlobStorageService blobService, UserManager<AppUser> userManager) 
        {
            _productRepository = productRepository;
            _blobService = blobService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int page, ClothingGender? gender, decimal? priceFrom, decimal? priceTo, SubCategory? category, string? sortBy, string? isActive)
        {
            var user = await _userManager.GetUserAsync(User);

            if (gender == null && priceFrom == null && priceTo == null && category == null && sortBy == null && isActive == null)
            {
                IEnumerable<Product> productsAll;
                if (User.IsInRole("admin") || User.IsInRole("employee")) 
                {
                    productsAll = await _productRepository.GetAll(page);
                }
                else
                {
                    productsAll = await _productRepository.GetAllActive(page);
                }
                
                if (productsAll == null)
                {
                    return NotFound();
                }

                return View(productsAll);
            }

            //isActive is allowed only for admins and employees
            if (!(User.IsInRole("admin") || User.IsInRole("employee")))
            {
                isActive = "activeOnly";
            }

            var productsF = await _productRepository.GetFiltered(page, gender, priceFrom, priceTo, category, sortBy, isActive);
            return View(productsF);
        }

        public async Task<IActionResult> Details(int id) 
        {
            var product = await _productRepository.GetByIdAsync(id);

            if(product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> ToggleActive(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            //isActive is allowed only for admins and employees
            if (!(User.IsInRole("admin") || User.IsInRole("employee")))
            {
                return Unauthorized();
            }

            var product = await _productRepository.GetByIdAsync(id);

            if (product != null)
            {
                product.IsActive = !product.IsActive;
                _productRepository.Update(product);
            }



            return RedirectToAction("Details", "Product", new { id = id });
        }

        public IActionResult Create()
        {
            return View();
        }

        private List<ProductVariantViewModel> VariantsViewModelfromDB(ICollection<ProductVariant> productVariants)
        {
            List<ProductVariantViewModel> newVariants = new List<ProductVariantViewModel>();

            foreach (var variant in productVariants)
            {
                List<VariantColorViewModel> newColors = new List<VariantColorViewModel>();
                foreach (var color in variant.VariantColors)
                {
                    newColors.Add(new VariantColorViewModel()
                    {
                        Id = variant.Id,
                        Color = color.Color
                    });
                }


                List<InternationalSizeQuantityViewModel> newInternationalSizeQuantities = new List<InternationalSizeQuantityViewModel>();
                List<ShoeSizeQuantityViewModel> newShoeSizeQuantities = new List<ShoeSizeQuantityViewModel>();

                if (variant.InternationalSizeQuantity != null)
                {

                    foreach (var sizeQuantity in variant.InternationalSizeQuantity)
                    {
                        newInternationalSizeQuantities.Add(new InternationalSizeQuantityViewModel()
                        {
                            Id = sizeQuantity.Id,
                            Size = sizeQuantity.Size,
                            Quantity = sizeQuantity.Quantity
                        });
                    }
                }
                else
                {

                    foreach (var sizeQuantity in variant.ShoeSizeQuantity)
                    {
                        newShoeSizeQuantities.Add(new ShoeSizeQuantityViewModel()
                        {
                            Id = sizeQuantity.Id,
                            Size = sizeQuantity.Size,
                            Quantity = sizeQuantity.Quantity
                        });
                    }
                }

                ProductVariantViewModel newVariant = new ProductVariantViewModel()
                {
                    Id = variant.Id,
                    Name = variant.Name,
                    Colors = newColors,
                    InternationalSizeQuantity = newInternationalSizeQuantities,
                    ShoeSizeQuantity = newShoeSizeQuantities
                };

                newVariants.Add(newVariant);
            }
            return newVariants;
        }

        private async Task<List<ProductVariant>> VariantsFromViewModelToDB(ICollection<ProductVariantViewModel> variants)
        {
            List<ProductVariant> newVariants = new List<ProductVariant>();

            foreach (ProductVariantViewModel variant in variants)
            {

                List<VariantColor> newColors = new List<VariantColor>();

                foreach (VariantColorViewModel color in variant.Colors)
                {
                    newColors.Add(new VariantColor()
                    {
                        Color = color.Color
                    });
                }

                List<InternationalSizeQuantity> newInternationalSizeQuantities = new List<InternationalSizeQuantity>();
                List<ShoeSizeQuantity> newShoeSizeQuantities = new List<ShoeSizeQuantity>();

                if (variant.InternationalSizeQuantity != null)
                {
                    foreach (InternationalSizeQuantityViewModel sizeQuantity in variant.InternationalSizeQuantity)
                    {
                        newInternationalSizeQuantities.Add(new InternationalSizeQuantity()
                        {
                            Size = sizeQuantity.Size,
                            Quantity = sizeQuantity.Quantity
                        });

                    }
                }
                else
                {

                    foreach (ShoeSizeQuantityViewModel sizeQuantity in variant.ShoeSizeQuantity)
                    {
                        newShoeSizeQuantities.Add(new ShoeSizeQuantity()
                        {
                            Size = sizeQuantity.Size,
                            Quantity = sizeQuantity.Quantity
                        });
                    }
                }

                List<Photo> newPhotos = new List<Photo>();

                foreach (IFormFile photo in variant.Photos)
                {
                    var cleanFileName = Path.GetFileNameWithoutExtension(photo.FileName).Replace(" ", "_") + Path.GetExtension(photo.FileName);
                    var photoUrl = await _blobService.UploadFileAsync(photo, cleanFileName);
                    newPhotos.Add(new Photo()
                    {
                        PhotoUrl = photoUrl
                    });
                }

                ProductVariant newVariant;

                newVariant = new ProductVariant()
                {
                    Name = variant.Name,
                    VariantColors = newColors,
                    InternationalSizeQuantity = newInternationalSizeQuantities,
                    ShoeSizeQuantity = newShoeSizeQuantities,
                    Photos = newPhotos
                };


                newVariants.Add(newVariant);
            }
            return newVariants;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel product)
        {
            if (ModelState.IsValid) 
            {
                List<ProductVariant> newVariants = new List<ProductVariant>();
                foreach (var variant in product.ProductVariants)
                {
                    List<VariantColor> newColors = new List<VariantColor>();
                    foreach (var color in variant.Colors)
                    {
                        newColors.Add(new VariantColor() { Color =  color.Color });
                    }


                    List<InternationalSizeQuantity> newInternationalSizeQuantities = new List<InternationalSizeQuantity>();
                    List<ShoeSizeQuantity> newShoeSizeQuantities = new List<ShoeSizeQuantity>();

                    if (product.Category != Category.Shoes) 
                    {
                        
                        foreach (var sizeQuantity in variant.InternationalSizeQuantity)
                        {
                            newInternationalSizeQuantities.Add(new InternationalSizeQuantity()
                            {
                                Size = sizeQuantity.Size,
                                Quantity = sizeQuantity.Quantity
                            });
                        }
                    }
                    else
                    {
                        foreach (var sizeQuantity in variant.ShoeSizeQuantity)
                        {
                            newShoeSizeQuantities.Add(new ShoeSizeQuantity()
                            {
                                Size = sizeQuantity.Size,
                                Quantity = sizeQuantity.Quantity
                            });
                        }
                    }

                    List<Photo> newPhotos = new List<Photo>();
                    foreach (var photo in variant.Photos) 
                    {
                        var cleanFileName = Path.GetFileNameWithoutExtension(photo.FileName).Replace(" ", "_") + Path.GetExtension(photo.FileName);
                        var photoUrl = await _blobService.UploadFileAsync(photo, cleanFileName);
                        newPhotos.Add(new Photo()
                        {
                            PhotoUrl = photoUrl
                        });
                    }

                    ProductVariant newVariant = new ProductVariant()
                    {
                        Name = variant.Name,
                        VariantColors = newColors,
                        InternationalSizeQuantity = newInternationalSizeQuantities,
                        ShoeSizeQuantity = newShoeSizeQuantities,
                        Photos = newPhotos
                    };

                    newVariants.Add(newVariant);
                }

                List<ProductMaterial> newMaterials = new List<ProductMaterial>();
                foreach (var material in product.ProductMaterials)
                {
                    newMaterials.Add(new ProductMaterial()
                    {
                        Material = material.Material
                    });
                }

                Product newProduct = new Product()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Gender = product.Gender,
                    Category = product.Category,
                    SubCategory = product.SubCategory,
                    ProductVariants = newVariants,
                    ProductMaterials = newMaterials,
                    Author = await _userManager.GetUserAsync(User),
                    IsActive = true
                };
                _productRepository.Add(newProduct);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            AppUser user = await _userManager.GetUserAsync(User);
            var product = await _productRepository.GetByIdAsync(id);

            if (user == null || !User.IsInRole("admin"))
            {
                return Unauthorized();
            }

            if(product == null)
                return NotFound();

            var newVariants = VariantsViewModelfromDB(product.ProductVariants);

            List<ProductMaterialViewModel> newMaterials = new List<ProductMaterialViewModel>();
            foreach (var material in product.ProductMaterials)
            {
                newMaterials.Add(new ProductMaterialViewModel()
                {
                    Id = material.Id,
                    Material = material.Material
                });
            }

            var productVM = new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Gender = product.Gender,
                Category = product.Category,
                SubCategory = product.SubCategory,
                ProductMaterials= newMaterials,
                ProductVariants = newVariants
            };
            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditProductViewModel productVM)
        {
            AppUser user = await _userManager.GetUserAsync(User);

            if (user == null || !User.IsInRole("admin"))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit product");
                return View("Edit", productVM);
            }

            var userProduct = await _productRepository.GetByIdAsyncNoTracking(id);

            if(userProduct != null)
            {
                List<int> materialIds = userProduct.ProductMaterials.Select(x => x.Id).ToList(); ;
                List<int> variantIds = userProduct.ProductVariants.Select(x => x.Id).ToList(); ;

                try
                {
                    foreach (var variant in userProduct.ProductVariants)
                    {
                        foreach(var photo in variant.Photos)
                        {
                            await _blobService.DeleteFileAsync(photo.PhotoUrl);
                        }
                    }     
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(productVM);
                }
                
                var newVariants = await VariantsFromViewModelToDB(productVM.ProductVariants);

                ///
                ///
                ////////////            Deleting old variants & variants' children
                ///
                ///

                foreach (var ogId in variantIds)
                {
                    ProductVariant toDelete = await _productRepository.GetProductVariantByIdAsync(ogId);
                    if (toDelete != null)
                    {
                        var colorsToDelete = await _productRepository.GetVariantColorsByVariantIdAsync(ogId);
                        var internationalSQToDelete = await _productRepository.GetInternationalSQByVariantIdAsync(ogId);
                        var shoeSQToDelete = await _productRepository.GetShoeSQByVariantIdAsync(ogId);
                            
                        if(colorsToDelete != null)
                        {
                            foreach(var color in colorsToDelete)
                            {
                                _productRepository.DeleteVariantColor(color);
                            }
                        }
                        if(internationalSQToDelete != null)
                        {
                            foreach (var sq in internationalSQToDelete)
                            {
                                _productRepository.DeleteInternationalSizeQuantity(sq);
                            }
                        }
                        if(shoeSQToDelete != null)
                        {
                            foreach (var sq in shoeSQToDelete)
                            {
                                _productRepository.DeleteShoeSizeQuantity(sq);
                            }
                        }
                        _productRepository.DeleteProductVariant(toDelete);
                    }
                }
                foreach(var ogId in materialIds)
                {
                    ProductMaterial toDelete = await _productRepository.GetProductMaterialByIdAsync(ogId);
                    if (toDelete != null)
                    {
                        _productRepository.DeleteProductMaterial(toDelete);
                    }
                }
                
                List<ProductMaterial> newMaterials = new List<ProductMaterial>();
                foreach (var material in productVM.ProductMaterials)
                {
                        newMaterials.Add(new ProductMaterial()
                        {
                            Material = material.Material
                        });
                }

                var product = new Product()
                {
                    Id = id,
                    Name = productVM.Name,
                    Description = productVM.Description,
                    Price = productVM.Price,
                    Gender = productVM.Gender,
                    Category = productVM.Category,
                    SubCategory = productVM.SubCategory,
                    ProductMaterials = newMaterials,
                    ProductVariants = newVariants
                };

                _productRepository.Update(product);
                return RedirectToAction("Index");
            }

            else 
            {
                return NotFound();
            }
        }
    }
}
