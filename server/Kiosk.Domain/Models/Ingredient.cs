using Kiosk.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Kiosk.Domain.Models
{
    public class Ingredient : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public double AddonPrice { get; set; }

        public Tag Tag { get; set; }

        public ICollection<ProductIngredient> Products { get; set; } = new List<ProductIngredient>();
    }
}
