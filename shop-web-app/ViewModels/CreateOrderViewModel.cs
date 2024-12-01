using shop_web_app.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace shop_web_app.ViewModels
{
    public class CreateOrderViewModel
    {
        public List<CartItem> ?CartItems { get; set; }
        public AppUser ?AppUser { get; set; }

        [Required(ErrorMessage ="Imię jest wymagane")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Nazwisko jest wymagane")]
        public string Surname { get; set; }

        public string ?BillingName { get; set; }
        public string ?BillingSurname { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany")]
        public Address DeliveryAddress { get; set; }
        public bool SaveAddress {  get; set; }
        public bool DifferentAddress { get; set; }
        public Address ?BillingAddress { get; set; }
    }
}
