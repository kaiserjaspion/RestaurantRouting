using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Ts.Restaurant.Order.Context.Models;

namespace Ts.Restaurant.Order.Context.Models
{
    [Table("Menu")]
    public class KitchenMenu : ContextBase
    {
        [Column("IdMenu"),Key,Required,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdMenu { get; set; }
        [Column("MenuName"),Required]
        public string MenuName { get; set; }
        [Column("MenuFoodType"),Required]
        public long MenuFoodType { get; set; }
        [ForeignKey("MenuFoodType")]
        public KitchenFoodType FoodType { get; set; }
        [Column("MenuAreaType"),Required]
        public long MenuAreaType { get; set; }
        [ForeignKey("MenuAreaType")]
        public KitchenAreas Area { get; set; }
    }
}
