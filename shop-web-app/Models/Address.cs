using shop_web_app.Enums;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models
{
    public class Address
    {
        [Key] 
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public Voivodship Voivodship { get; set; }
    }
}
