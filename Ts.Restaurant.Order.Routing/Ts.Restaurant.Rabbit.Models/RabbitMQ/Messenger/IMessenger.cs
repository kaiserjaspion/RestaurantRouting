namespace Ts.Restaurant.Order.RabbitMQ.RabbitMQ.Messenger
{
    public interface IMessenger
    {
        void SendMessage<T>(T data, string queueName) where T : class;
    }
}
