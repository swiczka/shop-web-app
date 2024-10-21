using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_web_app.Data;

namespace shop_web_app.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.ProductVariants)
                .Include(p => p.ProductMaterials)
                .ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }
    }
}
