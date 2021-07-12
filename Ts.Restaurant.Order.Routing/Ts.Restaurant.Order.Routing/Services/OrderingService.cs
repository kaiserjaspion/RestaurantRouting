using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ts.Restaurant.Order.Context.Contexts;
using Ts.Restaurant.Order.Routing.Models.Inserts;
using Ts.Restaurant.Order.Routing.Models.Results;
using Ts.Restaurant.Order.RabbitMQ.RabbitMQ.Messenger;
using Ts.Restaurant.Order.Context.Models;
using Ts.Restaurant.Order.Context.Repositories;
using Microsoft.Extensions.Logging;
using Ts.Restaurant.Order.Context.Repositories.Models;

namespace Ts.Restaurant.Order.Routing.Services
{
    public class OrderingService : IOrderingService
    {
        private IMessenger _messenger { get; set; }
        private readonly KitchenContext _context;
        private readonly OrderingRepository _repository;
        private readonly ILogger _logger;
        public OrderingService(IMessenger messenger, KitchenContext context)
        {
            _messenger = messenger;
            _context = context;
            _repository = new OrderingRepository(_logger,_context);
            _logger = new Logger<OrderingService>(new LoggerFactory());
        }

        //public OrderingService(IMessenger messenger,KitchenContext context)
        //{
        //    _messenger = messenger;
        //    _repository = new OrderingRepository(context);
        //}

        public OrderingResultData SendOrderingToKitchenQueue(TransitMenu ordering)
        {
            var returnData = new OrderingResultData();
            returnData.IsSent = false;
            try
            {
                _messenger.SendMessage(ordering, ordering.Area.AreaQueue);
                returnData.IsSent = true;
            }
            catch(Exception ex)
            {
                returnData.Message = ex.Message;
            }
            return returnData;
        }


        public async Task<List<TransitMenu>> GetMenus()
        {
            return await _repository.GetMenus();
        }
    }
}
