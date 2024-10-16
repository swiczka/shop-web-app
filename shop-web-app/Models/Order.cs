using System.ComponentModel.DataAnnotations;
using shop_web_app.Interfaces;
using shop_web_app.Enums;

namespace shop_web_app.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public List<OrderItem<ISizeQuantity<object>>> OrderItems { get; set; }
        public Customer Orderer { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status {  get; set; } 
    }
}
