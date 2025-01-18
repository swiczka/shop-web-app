using shop_web_app.Enums;
using shop_web_app.Models;

namespace shop_web_app.ViewModels
{
    public class OrderDetailsViewModel
    {
        public Order Order { get; set; }

        public OrderStatus? OrderStatus { get; set; }
        public int? OrderId { get; set; }
    }
}
