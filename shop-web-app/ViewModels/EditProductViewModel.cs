using shop_web_app.Enums;
using shop_web_app.Models;

namespace shop_web_app.ViewModels
{
    public class EditProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ClothingGender Gender { get; set; }
        public ICollection<ProductVariantViewModel> ProductVariants { get; set; } = new List<ProductVariantViewModel>();
        public ICollection<ProductMaterial> ProductMaterials { get; set; } = new List<ProductMaterial>();
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
