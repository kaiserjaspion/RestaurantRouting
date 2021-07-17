namespace Ts.Restaurant.Order.Messenger.Messenger
{
    public interface IMessenger
    {
        void SendMessage<T>(T data, string queueName) where T : class;
    }
}
