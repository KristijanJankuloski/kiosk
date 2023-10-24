using System.ComponentModel.DataAnnotations.Schema;

namespace Kiosk.Domain.Models
{
    public class ProductIngredient : BaseEntity
    {
        public long ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public long IngredientId { get; set; }

        [ForeignKey(nameof(IngredientId))]
        public Ingredient Ingredient { get; set; }
    }
}
