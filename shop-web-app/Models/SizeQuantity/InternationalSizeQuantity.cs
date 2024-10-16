using shop_web_app.Enums;
using shop_web_app.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models.SizeQuantity
{
    public class InternationalSizeQuantity : ISizeQuantity<InternationalSize>
    {
        [Key]
        public int Id { get; set; }
        public InternationalSize Size { get; set; }
        public int Quantity { get; set; }
    }
}
