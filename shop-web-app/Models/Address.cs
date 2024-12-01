using shop_web_app.Enums;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models
{
    public class Address
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Należy podać miasto.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Należy podać ulicę oraz numer domu/mieszkania.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Należy podać kod pocztowy.")]
        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Kod pocztowy musi być w formacie 'XX-XXX'.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Należy podać województwo.")]
        public Voivodship Voivodship { get; set; }
    }
}
