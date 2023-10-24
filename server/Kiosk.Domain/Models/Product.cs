using System.ComponentModel.DataAnnotations;

namespace Kiosk.Domain.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [MaxLength(255)]
        public string? ImageUrl { get; set; }

        public ICollection<ProductIngredient> Ingredients { get; set; } = new List<ProductIngredient>();

        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
