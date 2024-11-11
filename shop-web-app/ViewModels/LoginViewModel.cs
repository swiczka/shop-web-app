﻿using System.ComponentModel.DataAnnotations;

namespace shop_web_app.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Adres e-mail")]
        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}
