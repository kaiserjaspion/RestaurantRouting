using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Ts.Restaurant.Order.Context.Contexts;
using Ts.Restaurant.Order.RabbitMQ.RabbitMQ.Messenger;
using Ts.Restaurant.Order.RabbitMQ.RabbitMQ.Models;
using Ts.Restaurant.Order.Routing.Services;

namespace Ts.Restaurant.Order.Test
{
    public class OrderingTest
    {
        protected IOrderingService _orderingService;
        [SetUp]
        public void Setup(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }

        [Test]
        public async void GetMenuTest()
        {
            var menus = await _orderingService.GetMenus();
            Assert.Pass();
        }
    }
}