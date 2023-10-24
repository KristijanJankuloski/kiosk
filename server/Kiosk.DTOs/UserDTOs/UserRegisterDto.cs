using System.ComponentModel.DataAnnotations;

namespace Kiosk.DTOs.UserDTOs
{
    public class UserRegisterDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(125)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string PasswordConfirm { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
