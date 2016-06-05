using System;
using PubNubMessaging.Core;

namespace Iot.LightController.Messaging
{
    public class MessageBroker : IMessageBroker
    {
        protected Pubnub MessageQueue;

        protected MessageBroker()
        {

            MessageQueue = new Pubnub(
            PubNubParams.PubNubPublisherKey,
            PubNubParams.PubNubSuscriberKey,
            PubNubParams.PubNubSecret,
            PubNubParams.PubNubCipherKey,
            true);
        }
        
        public virtual void Initialize()
        {}
    }
}
