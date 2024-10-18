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

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public ProductVariant ProductVariant { get; set; }
        public decimal TotalPrice {
            get
            {
                return CalculateTotalPrice();
            }
        }

        private decimal CalculateTotalPrice()
        {
            if (ProductVariant == null)
            {
                return 0;
            }

            if (ProductVariant.InternationalSizeQuantity != null)
            {
                try
                {
                    return ProductVariant.InternationalSizeQuantity.Sum(sq => sq.Quantity) * ProductVariant.Product.Price;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 0;
                }
            }
            else if (ProductVariant.ShoeSizeQuantity != null)
            {
                try
                {
                    return ProductVariant.ShoeSizeQuantity.Sum(sq => sq.Quantity) * ProductVariant.Product.Price;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 0;
                }
            }
            else return 0;
        }
    }
}
