using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using shop_web_app.Enums;
using shop_web_app.Interfaces;

namespace shop_web_app.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int AddressId { get; set; }
        public Address ?Address { get; set; }
        public Gender ?Gender { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
