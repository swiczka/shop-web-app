using shop_web_app.Models;

namespace shop_web_app.ViewModels
{
    public class AccountInfoViewModel
    {
        public AppUser AppUser { get; set; }
        public List<Order> Orders { get; set; }
        public String? CurrentRole { get; set; }
        public String? NewRole { get; set; }
        public String? UserId { get; set; }

    }
}
