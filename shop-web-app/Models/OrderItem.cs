using shop_web_app.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models
{
    public class OrderItem<ISizeQuantity>
    {
        [Key]
        public int Id { get; set; }
        public IClothingItem<ISizeQuantity> Product { get; set; }
        public decimal TotalPrice {
            get
            {
                return CalculateTotalPrice();
            }

        }

        private decimal CalculateTotalPrice()
        {
            if (Product == null)
            {
                return 0;
            }
            return Product.SizeQuantity.Sum(sq => Product.SizeQuantity.Quantity) * Product.Price;
        }

    }
}
