using shop_web_app.Enums;
using shop_web_app.Models;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.ViewModels
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ClothingGender Gender { get; set; }
        public ICollection<ProductVariantViewModel> ProductVariants { get; set; } = new List<ProductVariantViewModel>();
        public ICollection<ProductMaterialViewModel> ProductMaterials { get; set; } = new List<ProductMaterialViewModel>();
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
