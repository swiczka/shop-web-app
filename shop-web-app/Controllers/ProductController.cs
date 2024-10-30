using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_web_app.Data;
using shop_web_app.Interfaces;
using shop_web_app.Models;
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
                //var result = await _blobService.UploadFileAsync(product.ProductVariants.)
            }
            //_productRepository.Add(product);
            return RedirectToAction("Index");
        }
    }
}
