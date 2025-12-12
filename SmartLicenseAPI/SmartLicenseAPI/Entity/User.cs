using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartLicenseAPI.Entity
{
    [Table("Users")]
    public class User
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto increment
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        public UserRole Role { get; set; }
        public enum UserRole
        {
            Admin = 1,
            User = 2
        }
    }
}

