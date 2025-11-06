using shop_web_app.Enums;

namespace shop_web_app.Models
{
    public class ProductMaterial
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Material Material { get; set; }
    }
}

