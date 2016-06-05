using System;
using PubNubMessaging.Core;

namespace Iot.LightController.Messaging
{
    public class SendBroker : MessageBroker, ISendBroker
    {
        public void SendMessage(string message)
        {
            MessageQueue.Publish(
                PubNubParams.PubNubChannel,
                message,
                PublishCallback,
                UnexpectedPublishErrorCallback);
        }

        public override void Initialize()
        {
            MessageQueue.Publish(
                PubNubParams.PubNubInitializationChannel,
                "INIT",
                PublishCallback,
                UnexpectedPublishErrorCallback);

        }

        private void PublishCallback(object result)
        { }

        private void UnexpectedPublishErrorCallback(PubnubClientError error)
        {
            throw new Exception(error.Message);
        }
    }
}