using shop_web_app.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models
{
    public class Employee : IUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
    }
}
