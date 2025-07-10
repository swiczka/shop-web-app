using shop_web_app.Models;

namespace shop_web_app.OtherModels
{
    public class UserWithRole
    {
        public AppUser User { get; set; }
        public string? Role { get; set; }
    }
}
