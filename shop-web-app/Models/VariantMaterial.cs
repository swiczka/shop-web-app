using shop_web_app.Models.Clothing;
using shop_web_app.Enums;

namespace shop_web_app.Models
{
    public class VariantMaterial
    {
        public int Id { get; set; }
        public int VariantId { get; set; }
        public ProductVariant Variant { get; set; }
        public Material Material { get; set; }
    }
}

