using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ts.Restaurant.Order.Context.Models
{
    [Table("Ingredient")]
    public class KitchenMenuIngredient : ContextBase
    {
        [Column("IdIngredient"),Key,Required,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdIngredient { get; set; }
        [Column("IngredientName"),Required]
        public string IngredientName { get; set; }
    }
}
