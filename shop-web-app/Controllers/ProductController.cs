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

            var productVM = new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Gender = product.Gender,
                Category = product.Category,
                SubCategory = product.SubCategory,
                ProductMaterials= product.ProductMaterials,
                ProductVariants = product.ProductVariants
            };
            return View(productVM);
        }
    }
}
