using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Ts.Restaurant.Order.Context.Models;

namespace Ts.Restaurant.Order.Context.Contexts
{
    public class KitchenContext : DbContext
    {
        public string ConnectionName;
        public KitchenContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<KitchenAreas> Areas { get; set; }
        public DbSet<KitchenMenu> Menus { get; set; }
        public DbSet<KitchenMenuIngredient> Ingredients { get; set; }
        public DbSet<KitchenFoodType> FoodTypes { get; set; }
        public DbSet<KitchenTransitMenuIngredient> MenuIngredients { get; set; }

       
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=localhost\\SQLEXPRESS;Database=DbKitchenQueue;User ID=KitchenOrder;Password=bptrtor21;Trusted_Connection=True;", 
        //        sqlServerOptions => sqlServerOptions.CommandTimeout(180));
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
