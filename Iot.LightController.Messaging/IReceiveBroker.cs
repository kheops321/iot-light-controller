namespace Iot.LightController.Messaging
{
    public interface IReceiveBroker : IMessageBroker
    {
        void StartListening();

        event ReceivedMessageEventHandler OnReceivedMessage;
    }
}