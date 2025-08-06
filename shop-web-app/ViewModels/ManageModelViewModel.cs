using shop_web_app.Models;

namespace shop_web_app.ViewModels
{
    public class ManageModelViewModel
    {
        public Product Product { get; set; }
        public IFormFile ModelFile { get; set; }
        public bool HasModel { get; set; }
        public int ProductId { get; set; }
    }
}
