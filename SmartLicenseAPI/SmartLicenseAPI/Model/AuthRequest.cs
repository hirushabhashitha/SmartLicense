using System.ComponentModel.DataAnnotations;

namespace SmartLicenseAPI.Model
{
    public class AuthRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(255)]
        public string Password { get; set; }
    }
}
