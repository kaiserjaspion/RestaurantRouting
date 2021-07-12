using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ts.Restaurant.Order.Routing.Models
{
    public class Base
    {
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
