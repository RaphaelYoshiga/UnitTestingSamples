using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outside.Training.AdvancedTddSample
{
    public class PageVisitToBrokeredMessageParser : IPageVisitToBrokeredMessageParser
    {
        public BrokeredMessage Parse(PageVisit pageVisit)
        {
            var serializedObject = JsonConvert.SerializeObject(pageVisit);
            return new BrokeredMessage(serializedObject);
        }
    }
}
