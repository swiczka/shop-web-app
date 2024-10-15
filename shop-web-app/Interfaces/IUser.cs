using shop_web_app.Enums;
using shop_web_app.Models;

namespace shop_web_app.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Password { get; set; }
        string Email { get; set; }
    }
}