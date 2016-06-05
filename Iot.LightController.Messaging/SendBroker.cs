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
                GetResult,
                WhenErrorHandeled);
        }

        public override void Initialize()
        {
            MessageQueue.Publish(
                PubNubParams.PubNubInitializationChannel,
                "INIT",
                GetResult,
                WhenErrorHandeled);

        }

        private void GetResult(object result)
        { }

        private void WhenErrorHandeled(PubnubClientError error)
        {
            throw new Exception(error.Message);
        }
    }
}