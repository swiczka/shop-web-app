using shop_web_app.Enums;
using shop_web_app.Models.SizeQuantity;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models
{
    public class ProductVariant
    {
        [Key]
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string Name { get; set; }

        public ICollection<VariantColor> VariantColors { get; set; } = new List<VariantColor>();

        [Required]
        public ICollection<Photo> Photos { get; set; }

        //depending of clothing kind, one remains null
        public ICollection<InternationalSizeQuantity> ?InternationalSizeQuantity { get; set; }
        public ICollection<ShoeSizeQuantity> ?ShoeSizeQuantity { get; set; }
    }
}
