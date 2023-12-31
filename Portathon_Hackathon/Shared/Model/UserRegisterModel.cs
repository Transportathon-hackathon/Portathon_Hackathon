﻿using System.ComponentModel.DataAnnotations;

namespace Portathon_Hackathon.Shared.Model
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Email alanı gereklidir"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı gereklidir"), EmailAddress]
        public string Username { get; set; }

        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "pasword do not match")]
        public string ConfirmPassword { get; set; }
        public UserTypes UserType { get; set; }
    }
    public enum UserTypes
    {
        User,
        Company,
    }
}
