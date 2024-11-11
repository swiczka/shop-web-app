using shop_web_app.Enums;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Imię jest wymagane")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Surname { get; set; }

        [Display(Name = "Adres e-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        public string Email { get; set; }

        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Hasło jest wymagane")]
        public string Password { get; set; }

        [Display(Name = "Potwierdź hasło")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła muszą się zgadzać")]
        [Required(ErrorMessage = "Powtórzenie hasła jest wymagane")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Płeć")]
        [Required(ErrorMessage = "Płeć jest wymagana")]
        public Gender ?Gender { get; set; }
    }
}
