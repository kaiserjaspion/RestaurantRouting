using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;
using Ts.Restaurant.Order.Context.Repositories.Models;

namespace Ts.Restaurant.Order.KitchnQueue.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = args[1], Password = args[2], UserName = args[3] };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: args[0],
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                var message = String.Empty;
                consumer.Received += (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body.ToArray();
                        message = Encoding.UTF8.GetString(body);

                        Console.WriteLine(message);
                        if (message != null)
                        {
                            using (StreamWriter sw = new StreamWriter(args[4], true, Encoding.ASCII))
                            {
                                //Write a line of text
                                sw.WriteLine(message + "\n");
                                //Write a second line of text
                                //Close the file
                                sw.Close();
                            }
                        }

                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                            //Log (Nack para dizer que o consumo da msg não foi possível)
                            // DelivaryTag -> Carimbo de entrega
                            // 3° Parametro recoloca ou não a msg na fila novamente
                            channel.BasicNack(ea.DeliveryTag, false, true);
                    }
                };

            }
        }
    }
}