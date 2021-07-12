using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ts.Restaurant.Order.Context.Models
{
    [Table("MenuIngredient")]
    public class KitchenTransitMenuIngredient :ContextBase
    {
        [Column("IdMenuIngredient"), Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdMenuIngredient { get; set; }
        [Column("IdIngredient"), Required, ForeignKey("Ingredient")]
        public long IdIngredient { get; set; }
        [Column("IdMenu"), Required, ForeignKey("Menu")]
        public long IdMenu { get; set; }
        [Column("IngredientQuantity"), Required]
        public decimal IngredientQuantity { get; set; }
    }
}
