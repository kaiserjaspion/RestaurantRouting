using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ts.Restaurant.Order.Context.Contexts;
using Ts.Restaurant.Order.Context.Models;
using Ts.Restaurant.Order.Context.Repositories.Models;
using Ts.Restaurant.Order.Routing.Models.Inserts;
using Ts.Restaurant.Order.Routing.Models.Results;
using Ts.Restaurant.Order.Routing.Services;

namespace Ts.Restaurant.Order.Routing.Controllers
{
    public class OrderingController : Controller
    {
        private readonly ILogger _logger;
        protected readonly IOrderingService _orderingService;
        private readonly KitchenContext _context;

        public OrderingController(IOrderingService orderingService,KitchenContext context)
        {
            _orderingService = orderingService;
            _context = context;
            _logger = new Logger<OrderingController>(new LoggerFactory());
        }

        [HttpPost("SendOrder")]
        public OrderingResultData OrderService([FromBody] TransitMenu ordering)
        {
            try
            {
                return _orderingService.SendOrderingToKitchenQueue(ordering);
            }
            catch(Exception ex)
            {
                _logger.LogError("Erro placing order", ex);
                return new OrderingResultData { Message = "Erro placing order"  };
            }
        }

        [HttpGet("Menu")]
        public async Task<List<TransitMenu>> GetMenus()
        {
            try
            {
                return await _orderingService.GetMenus();
            }
            catch(Exception ex)
            {
                _logger.LogError("Error retriving menu", ex);
                return null;
            }
        }
    }
}
