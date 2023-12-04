using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Agrogar.Shared.DTOs
{
    public class UserRegisterDTO
    {

        [Required]
        public string Name { get; set; } 
        [Required, EmailAddress]
        public string Email { get; set; } 
        [Required, StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }
        [Required, Compare("Password", ErrorMessage = "La contraseña no coincide")]
        public string ConfirmPassword { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }
        public bool LicensePP { get; set; }

    }
}
