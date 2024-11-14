using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models.Clothing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop_web_app.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int ?OrderId { get; set; }
        public Order ?Order { get; set; }

        public int VariantId { get; set; }
        public ProductVariant Variant { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public InternationalSize ?InternationalSize { get; set; }
        public ShoeSize ?ShoeSize {  get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

       
    }
}
