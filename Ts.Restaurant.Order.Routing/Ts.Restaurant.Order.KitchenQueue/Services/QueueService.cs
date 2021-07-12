using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ts.Restaurant.Order.Context.Repositories.Models;
using Ts.Restaurant.Order.RabbitMQ.RabbitMQ.Models;

namespace Ts.Restaurant.Order.KitchenQueue.Services
{
    public class QueueService : IQueueService
    {
    

        

        public QueueService(IConfiguration config, IOptions<RabbitOptions> rabbit)
        {
            
        }

        public async Task<List<TransitMenu>> ReceiveQueue()
        {
            var transitReturn = new List<TransitMenu>();
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader("C:\\Sample.txt");
            //Read the first line of text
            var lines = sr.ReadLine().Split('\n');
            //Continue to read until you reach end of file
            foreach(var line in lines)
            {
                transitReturn.Add(JsonConvert.DeserializeObject<TransitMenu>(line));
            }
            //close the file
            sr.Close();
            Console.ReadLine();

            return transitReturn;

        }
    }
}
