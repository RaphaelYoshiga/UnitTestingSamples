using Microsoft.ServiceBus.Messaging;

namespace Outside.Training.AdvancedTddSample
{
    public interface IServiceBusMessageSender
    {
        void SendMessage(BrokeredMessage message);
    }
}