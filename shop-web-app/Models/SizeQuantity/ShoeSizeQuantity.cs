using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models.Clothing;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models.SizeQuantity
{
    public class ShoeSizeQuantity : ISizeQuantity<ShoeSize>
    {
        [Key]
        public int Id { get; set; }

        public int VariantId { get; set; }
        public ProductVariant Variant { get; set; }

        public ShoeSize Size { get; set; }
        public int Quantity { get; set; }
    }
}
