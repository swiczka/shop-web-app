using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using shop_web_app.Data;
using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models;
using shop_web_app.Models.SizeQuantity;
using shop_web_app.Services;
using shop_web_app.ViewModels;

namespace shop_web_app.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly BlobStorageService _blobService;

        public ProductController(IProductRepository productRepository, BlobStorageService blobService) 
        {
            _productRepository = productRepository;
            _blobService = blobService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAll();

            if (products == null)
            {
                return NotFound();
            }

            return View(products);
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

        public IActionResult Create()
        {
            return View();
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

                    if (variant.InternationalSizeQuantity != null) 
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
                        var photoUrl = await _blobService.UploadFileAsync(photo);
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
                        //{
                        //    new Photo()
                        //    {
                        //        PhotoUrl = "https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png"
                        //    }
                        //}
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
                    ProductMaterials = newMaterials
                };
                _productRepository.Add(newProduct);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            
            if(product == null)
                return View("Error");



            List<ProductVariantViewModel> newVariants = new List<ProductVariantViewModel>();
            foreach (var variant in product.ProductVariants)
            {
                List<VariantColorViewModel> newColors = new List<VariantColorViewModel>();
                foreach (var color in variant.VariantColors)
                {
                    newColors.Add(new VariantColorViewModel() { Color = color.Color });
                }
                

                List<InternationalSizeQuantityViewModel> newInternationalSizeQuantities = new List<InternationalSizeQuantityViewModel>();
                List<ShoeSizeQuantityViewModel> newShoeSizeQuantities = new List<ShoeSizeQuantityViewModel>();

                if (variant.InternationalSizeQuantity != null)
                {

                    foreach (var sizeQuantity in variant.InternationalSizeQuantity)
                    {
                        newInternationalSizeQuantities.Add(new InternationalSizeQuantityViewModel()
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
                        newShoeSizeQuantities.Add(new ShoeSizeQuantityViewModel()
                        {
                            Size = sizeQuantity.Size,
                            Quantity = sizeQuantity.Quantity
                        });
                    }
                }

                ProductVariantViewModel newVariant = new ProductVariantViewModel()
                {
                    Name = variant.Name,
                    Colors = newColors,
                    InternationalSizeQuantity = newInternationalSizeQuantities,
                    ShoeSizeQuantity = newShoeSizeQuantities
                };

                newVariants.Add(newVariant);
            }

            List<ProductMaterialViewModel> newMaterials = new List<ProductMaterialViewModel>();
            foreach (var material in product.ProductMaterials)
            {
                newMaterials.Add(new ProductMaterialViewModel()
                {
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
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit product");
                return View("Edit", productVM);
            }

            var userProduct = await _productRepository.GetByIdAsyncNoTracking(id);

            if(userProduct != null)
            {
                try
                {
                    foreach(var variant in userProduct.ProductVariants)
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

                

                List<ProductVariant> newVariants = new List<ProductVariant>();
                foreach (ProductVariantViewModel variant in productVM.ProductVariants)
                {
                    List<VariantColor> newColors = new List<VariantColor>();
                    foreach (VariantColorViewModel color in variant.Colors)
                    {
                        newColors.Add(new VariantColor() { Color = color.Color });
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

                    foreach (var photo in variant.Photos)
                    {
                        var photoUrl = await _blobService.UploadFileAsync(photo);
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
                return View(productVM);
            }
        }
    }
}
