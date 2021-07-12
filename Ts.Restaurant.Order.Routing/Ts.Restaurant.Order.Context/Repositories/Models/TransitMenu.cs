using System;
using System.Collections.Generic;
using System.Text;
using Ts.Restaurant.Order.Context.Models;

namespace Ts.Restaurant.Order.Context.Repositories.Models
{
    public class TransitMenu: KitchenMenu
    {
        public List<TransitIngredient> Ingredients { get; set; }
    }

    public class TransitIngredient: KitchenMenuIngredient
    {
        public decimal QtdItem { get; set; }
    }
}
