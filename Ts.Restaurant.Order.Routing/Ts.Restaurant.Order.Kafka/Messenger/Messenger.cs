using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Ts.Restaurant.Order.Messenger.Messenger;

namespace Ts.Restaurant.Order.Kafka.Messenger
{
    public class Messenger : IMessenger
    {
        public Messenger()
        {

        }

        public void SendMessage<T>(T data, string queueName) where T : class
        {
            try
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = "host1:9092,host2:9092"
                };

                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    
                        var result = producer.ProduceAsync(
                            queueName,
                            new Message<Null, string>
                            { Value = JsonConvert.SerializeObject(data) });

                       
                }

            }
            catch (Exception ex)
            {
            }
        }
    }
}
