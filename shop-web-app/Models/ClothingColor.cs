using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models.Clothing;
using shop_web_app.Models.SizeQuantity;

namespace shop_web_app.Models
{
    public class ClothingColor
    {
        public int ProductId { get; set; }
        public ClothingItem<ISizeQuantity, > Product { get; set; }
        public Color Color { get; set; }
    }
}
