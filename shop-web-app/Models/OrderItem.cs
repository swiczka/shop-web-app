using shop_web_app.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models
{
    public class OrderItem<TSizeQuantity> where TSizeQuantity : ISizeQuantity<object>
    {
        [Key]
        public int Id { get; set; }
        public IClothingItem<TSizeQuantity> Product { get; set; }
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
            return Product.SizeQuantity.Sum(sq => sq.Quantity) * Product.Price;
        }

    }
}
