using System.ComponentModel.DataAnnotations;

namespace Kiosk.DTOs.UserDTOs
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
