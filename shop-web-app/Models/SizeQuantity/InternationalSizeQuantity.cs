using shop_web_app.Enums;
using shop_web_app.Interfaces;

namespace shop_web_app.Models.SizeQuantity
{
    public class InternationalSizeQuantity : ISizeQuantity<InternationalSize>
    {
        public InternationalSize Size { get; set; }
        public int Quantity { get; set; }
    }
}
