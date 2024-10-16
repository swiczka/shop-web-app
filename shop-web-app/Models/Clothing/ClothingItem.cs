//Class with basic fields shared by all kinds of clothing: shoes, shirts, pants, etc..

using shop_web_app.Enums;
using shop_web_app.Models.SizeQuantity;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models.Clothing
{
    public class ClothingItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ClothingType Type { get; set; }
        public List<InternationalSizeQuantity> SizeQuantity { get; set; } = new List<InternationalSizeQuantity>();
        public ClothingGender Gender { get; set; }
        public List<Color> Colors { get; set; } = new List<Color>();
        public List<Material> Materials { get; set; } = new List<Material>();
    }
}
