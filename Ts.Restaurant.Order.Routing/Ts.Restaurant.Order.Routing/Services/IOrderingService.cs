using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ts.Restaurant.Order.Context.Models;
using Ts.Restaurant.Order.Context.Repositories.Models;
using Ts.Restaurant.Order.Routing.Models.Inserts;
using Ts.Restaurant.Order.Routing.Models.Results;

namespace Ts.Restaurant.Order.Routing.Services
{
    public interface IOrderingService
    {
        OrderingResultData SendOrderingToKitchenQueue(TransitMenu ordering);
        Task<List<TransitMenu>> GetMenus();
    }
}
