using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kiosk.Domain.Models
{
    public class UserRefreshToken: BaseEntity
    {
        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public string RefreshToken { get; set; }

        public DateTime ExpireTime { get; set; }
    }
}
