using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ts.Restaurant.Order.Context.Repositories.Models;

namespace Ts.Restaurant.Order.KitchenQueue.Services
{
    public interface IQueueService
    {
        Task<List<TransitMenu>> ReceiveQueue();
    }
}
