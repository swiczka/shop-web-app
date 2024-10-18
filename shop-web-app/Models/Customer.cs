using System.ComponentModel.DataAnnotations;
using shop_web_app.Enums;
using shop_web_app.Interfaces;

namespace shop_web_app.Models
{
    public class Customer : IUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Address ?Address { get; set; }
        public Gender ?Gender { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
