using Microsoft.ServiceBus.Messaging;

namespace Outside.Training.AdvancedTddSample
{
    public interface IPageVisitToBrokeredMessageParser
    {
        BrokeredMessage Parse(PageVisit pageVisit);
    }
}