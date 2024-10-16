using shop_web_app.Models.Clothing;
using shop_web_app.Enums;

namespace shop_web_app.Models
{
    public class ClothingMaterial
    {
        public int ProductId { get; set; }
        public ClothingItem<object, object> Product { get; set; }
        public Material Material { get; set; }
    }
}
}
