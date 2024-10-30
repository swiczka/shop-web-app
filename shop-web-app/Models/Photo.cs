using shop_web_app.Enums;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public int VariantId { get; set; }
        public ProductVariant Variant { get; set; }
        
        [StringLength(255)]
        public string PhotoUrl { get; set; }
    }
}
