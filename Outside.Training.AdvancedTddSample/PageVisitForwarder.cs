using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outside.Training.AdvancedTddSample
{
    public class PageVisitForwarder
    {
        private IPageVisitToBrokeredMessageParser _messageParser;
        private IServiceBusMessageSender _serviceBusMessageSender;

        public PageVisitForwarder(IPageVisitToBrokeredMessageParser messageParser, IServiceBusMessageSender serviceBusMessageSender)
        {
            _messageParser = messageParser;
            _serviceBusMessageSender = serviceBusMessageSender;
        }

        public void ForwardMessage(PageVisit pageVisit)
        {
            if (pageVisit == null)
                throw new ArgumentNullException("pageVisit");

            if (string.IsNullOrEmpty(pageVisit.PageUrl))
                throw new ArgumentNullException("pageVisit.PageUrl");

            var message = _messageParser.Parse(pageVisit);
            _serviceBusMessageSender.SendMessage(message);
        }
    }
}
