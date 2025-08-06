using System.ComponentModel.DataAnnotations;
using shop_web_app.Enums;

namespace shop_web_app.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
        public ClothingGender Gender { get; set; }
        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
        public ICollection<ProductMaterial> ProductMaterials { get; set; } = new List<ProductMaterial>();
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public string ?AuthorId { get; set; }
        public AppUser ?Author { get; set; }
        public bool IsActive { get; set; } = true;
        public bool HasModel { get; set; } = false;
        public string ?ModelUrl { get; set; }
    }
}
