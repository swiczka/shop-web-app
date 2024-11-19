using shop_web_app.Models;

namespace shop_web_app.ViewModels
{
    public class CreateOrderViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public AppUser AppUser { get; set; }
    }
}
