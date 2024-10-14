using System.ComponentModel.DataAnnotations;
using shop_web_app.Enums;

namespace shop_web_app.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Address ?Address { get; set; }
        public Gender ?Gender { get; set; }

    }
}
