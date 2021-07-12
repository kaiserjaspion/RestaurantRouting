using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ts.Restaurant.Order.Context.Repositories.Models;
using Ts.Restaurant.Order.KitchenQueue.Models;
using Ts.Restaurant.Order.KitchenQueue.Services;
using Ts.Restaurant.Order.RabbitMQ.RabbitMQ.Models;

namespace Ts.Restaurant.Order.KitchenQueue.Controllers
{
    public class QueueController : Controller
    {
        private readonly IQueueService _queueService;
        private readonly string _queue;
        private readonly IConfiguration _configuration;
        private IModel _channel;
        private IConnection _connection;
        private readonly RabbitOptions _rabbit;

        public QueueController(IConfiguration configuration, IQueueService queueService ,  IOptions<RabbitOptions> rabbit )
        {
            _queueService = queueService;
        }

        [HttpGet("LastOrder")]
        public async Task<List<TransitMenu>> ReceiveQueue()
        {
            return await _queueService.ReceiveQueue();
        }
    }
}