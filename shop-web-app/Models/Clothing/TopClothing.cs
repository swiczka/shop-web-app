using shop_web_app.Interfaces;
using shop_web_app.Enums;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models.Clothing
{
    public class TopClothing : IClothingItem<InternationalSize>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public InternationalSize Size { get; set; }
        public TopType Type { get; set; }
        public ClothingGender Gender { get; set; }
        public List<Color> Colors { get; set; }
        public List<Material> Materials { get; set; }
    }
}
