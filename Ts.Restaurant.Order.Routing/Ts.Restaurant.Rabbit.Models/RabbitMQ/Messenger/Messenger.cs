using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using Ts.Restaurant.Order.RabbitMQ.RabbitMQ.Models;

namespace Ts.Restaurant.Order.RabbitMQ.RabbitMQ.Messenger
{
    public class Messenger : IMessenger
    {
        private IConnection _connection;
        private IModel _channel;
        private RabbitOptions _rabbitOptions;

        public Messenger(IOptions<RabbitOptions> rabbitOptions)
        {
           
            _rabbitOptions = rabbitOptions.Value;
            var factory = new ConnectionFactory() { HostName = _rabbitOptions.HostName, Password = _rabbitOptions.Password, UserName = _rabbitOptions.UserName };
            _connection = factory.CreateConnection();
        }

        public Messenger(RabbitOptions rabbitOptions)
        {
            _rabbitOptions = rabbitOptions;
            var factory = new ConnectionFactory() { HostName = _rabbitOptions.HostName, Password = _rabbitOptions.Password, UserName = _rabbitOptions.UserName };
            _connection = factory.CreateConnection();
        }


        // Este método recebe qualquer objeto, desde que seja uma classe
        public void SendMessage<T>(T data, string queueName) where T : class
        {
            try
            {

                
                _channel = _connection.CreateModel();

                _channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                string message = JsonConvert.SerializeObject(data);
                var body = Encoding.UTF8.GetBytes(message);

                _channel.BasicPublish(exchange: "",
                             routingKey: queueName,
                             basicProperties: null,
                             body: body);

                Console.WriteLine(" [x] Sent {0}", message);

                _channel.Dispose();
                _connection.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve um erro ao enviar mensagem à fila {queueName}. {ex.Message}");
            }
        }

    }
}

