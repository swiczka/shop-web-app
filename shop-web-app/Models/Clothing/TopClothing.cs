using shop_web_app.Interfaces;
using shop_web_app.Enums;
using System.ComponentModel.DataAnnotations;
using shop_web_app.Models.SizeQuantity;

namespace shop_web_app.Models.Clothing
{
    public class TopClothing : IClothingItem<InternationalSizeQuantity>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TopType Type { get; set; }
        public ClothingGender Gender { get; set; }
        public List<Color> Colors { get; set; } = new List<Color>();
        public List<Material> Materials { get; set; } = new List<Material>();
        public List<InternationalSizeQuantity> SizeQuantity { get; set; } = new List<InternationalSizeQuantity>();
    }
}
