using System;
using System.Diagnostics;
using Newtonsoft.Json;
using PubNubMessaging.Core;

namespace Iot.LightController.Messaging
{
    public class ReceiveBroker : MessageBroker, IReceiveBroker
    {
        public event ReceivedMessageEventHandler OnReceivedMessage;

        public void StartListening()
        {
            if(MessageQueue == null)
                throw new NotSupportedException("Please initialize the broker befor start listening");

            MessageQueue.Subscribe<string>(
                PubNubParams.PubNubChannel,
                ReceivedMessageCallback,
                ConnectionEstablishedCallback,
                ErrorHandeledCallback);
        }

        private void ReceivedMessageCallback(string receivedMessage)
        {
            var message = JsonConvert.DeserializeObject<string[]>(receivedMessage)[0];
            Debug.WriteLine("RECEIVED MESSAGE: " + message);
            OnReceivedMessage?.Invoke(message);
        }

        private void ConnectionEstablishedCallback(string connectionStatusMessage)
        {
            Debug.WriteLine("CONNECTION: " + connectionStatusMessage);
        }

        private void ErrorHandeledCallback(PubnubClientError error)
        {
            Debug.WriteLine("UNEXPECTED ERRER: " + error);
        }

    }
}