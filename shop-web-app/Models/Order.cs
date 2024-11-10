using System.ComponentModel.DataAnnotations;
using shop_web_app.Interfaces;
using shop_web_app.Enums;

namespace shop_web_app.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public string OrdererId { get; set; }
        public AppUser Orderer { get; set; }

        public DateTime OrderDate { get; set; }
        public OrderStatus Status {  get; set; } 
    }
}
