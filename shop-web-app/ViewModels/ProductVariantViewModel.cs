using System.ComponentModel.DataAnnotations;

namespace shop_web_app.ViewModels
{
    public class ProductVariantViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public List<VariantColorViewModel> Colors { get; set; } = new List<VariantColorViewModel>();

        public List<IFormFile> Photos { get; set; } = new List<IFormFile>();

        public List<InternationalSizeQuantityViewModel> InternationalSizeQuantities { get; set; } = new List<InternationalSizeQuantityViewModel>();

        public List<ShoeSizeQuantityViewModel> ShoeSizeQuantities { get; set; } = new List<ShoeSizeQuantityViewModel>();
    }
}
