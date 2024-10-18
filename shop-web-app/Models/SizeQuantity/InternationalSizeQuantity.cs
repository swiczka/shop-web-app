using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models.Clothing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop_web_app.Models.SizeQuantity
{
    public class InternationalSizeQuantity : ISizeQuantity<InternationalSize>
    {
        [Key]
        public int Id { get; set; }


        public int VariantId { get; set; }
        public ProductVariant Variant { get; set; }
        
        public InternationalSize Size { get; set; }
        public int Quantity { get; set; }
    }
}
