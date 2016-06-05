namespace Iot.LightController.Messaging
{
    public interface ISendBroker : IMessageBroker
    {
        void SendMessage(string message);
    }
}