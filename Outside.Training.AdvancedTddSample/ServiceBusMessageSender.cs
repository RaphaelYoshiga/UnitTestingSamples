using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outside.Training.AdvancedTddSample
{
    public class ServiceBusMessageSender : IServiceBusMessageSender
    {
        public void SendMessage(BrokeredMessage message)
        {
            var topicClient = TopicClient.CreateFromConnectionString(ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"], "topicName");
            topicClient.Send(message);
        }
    }
}
