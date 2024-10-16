using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models.Clothing;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models.SizeQuantity
{
    public class ShoeSizeQuantity : ISizeQuantity<ShoeSize>
    {
        [Key]
        public string Id { get; set; }

        public int ShoeId { get; set; }
        public ShoeClothing Shoe { get; set; }

        public ShoeSize Size { get; set; }
        public int Quantity { get; set; }
    }
}
