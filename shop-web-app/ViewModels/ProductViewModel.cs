using shop_web_app.Models;

namespace shop_web_app.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public int LastPage { get; set; }

    }
}
