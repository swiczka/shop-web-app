using shop_web_app.Models;

namespace shop_web_app.ViewModels
{
    public class DashboardViewModel
    {
        public AppUser AppUser { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> ?Products { get; set; }

    }
}
