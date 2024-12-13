using shop_web_app.Enums;
using shop_web_app.Models;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.ViewModels
{
    public class EditAccountViewModel
    {
        public AppUser AppUser { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Imię jest wymagane")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Surname { get; set; }

        [Display(Name = "Stare hasło")]
        [DataType(DataType.Password)]
        public string? OldPassword { get; set; }

        [Display(Name = "Nowe hasło")]
        [DataType(DataType.Password)]
        public string ?Password { get; set; }

        [Display(Name = "Potwierdź nowe hasło")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła muszą się zgadzać")]
        public string ?ConfirmPassword { get; set; }

        [Display(Name = "Płeć")]
        public Gender ?Gender { get; set; }

        //public Address ?Address { get; set; }


        [Display(Name = "Ulica i numer domu")]
        public string? Street { get; set; }

        [Display(Name = "Miasto")]
        public string? City { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string? PostalCode { get; set; }

        [Display(Name = "Voivodship")]
        public Voivodship? Voivodship { get; set; }

    }
}
