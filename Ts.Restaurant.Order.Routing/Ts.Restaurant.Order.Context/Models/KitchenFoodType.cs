using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ts.Restaurant.Order.Context.Models
{
    [Table("FoodType")]
    public class KitchenFoodType : ContextBase
    {
        [Column("IdFood"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public long IdFood { get; set; }
        [Column("FoodName"), Required]
        public string FoodName { get; set; }
    }
}
