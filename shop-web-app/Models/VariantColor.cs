using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models.Clothing;
using shop_web_app.Models.SizeQuantity;

namespace shop_web_app.Models
{
    public class VariantColor
    {
        public int Id { get; set; }
        public int VariantId { get; set; }
        public ProductVariant Variant { get; set; }
        public Color Color { get; set; }
    }
}
