using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ts.Restaurant.Order.Context.Contexts;
using Ts.Restaurant.Order.Context.Models;
using Ts.Restaurant.Order.Context.Repositories.Models;

namespace Ts.Restaurant.Order.Context.Repositories
{
    public class OrderingRepository
    {
        private readonly KitchenContext _context;
        private readonly ILogger _logger;
        public OrderingRepository(ILogger logger,KitchenContext context)
        {
            _context = context;
            _logger = logger;
        }

        public OrderingRepository(KitchenContext context)
        {
            _context = context;
            _logger = new Logger<OrderingRepository>(new LoggerFactory());
        }

        public async Task<List<TransitMenu>> GetMenus()
        {
            try
            {
                return await _context.Menus
                    .Where(x => x.IsActive)
                    .Select(x => new TransitMenu
                    {
                        Area = _context.Areas.Where(y => y.IdArea == x.MenuAreaType).FirstOrDefault(),
                        FoodType = _context.FoodTypes.Where(y => y.IdFood == x.MenuFoodType).FirstOrDefault(),
                        IdMenu = x.IdMenu,
                        MenuName = x.MenuName,
                        MenuFoodType = x.MenuFoodType,
                        MenuAreaType = x.MenuAreaType,
                        IsActive = x.IsActive,
                        DtCreated = x.DtCreated,
                        CreatedBy = x.CreatedBy,
                        Ingredients = _context.MenuIngredients.Where(z => z.IdMenu == x.IdMenu)
                            .SelectMany(c => _context.Ingredients.Where(y => y.IdIngredient == c.IdIngredient)
                            , (c, i) => new { ingredients = i , data = c}).Select(x =>  new TransitIngredient
                                {
                                    IdIngredient = x.ingredients.IdIngredient,
                                    IngredientName = x.ingredients.IngredientName,
                                    QtdItem = x.data.IngredientQuantity,
                                    IsActive = x.ingredients.IsActive,
                                    DtCreated = x.ingredients.DtCreated,
                                    CreatedBy = x.ingredients.CreatedBy
                                }
                            ).ToList()
                    })
                    .ToListAsync()
                    ;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error retriving data from database",ex);
                return null;
            }
        }


    }
}
