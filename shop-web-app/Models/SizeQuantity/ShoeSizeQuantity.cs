using shop_web_app.Enums;
using shop_web_app.Interfaces;

namespace shop_web_app.Models.SizeQuantity
{
    public class ShoeSizeQuantity : ISizeQuantity<ShoeSize>
    {
        public ShoeSize Size { get; set; }
        public int Quantity { get; set; }
    }
}
