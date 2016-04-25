using Microsoft.ServiceBus.Messaging;
using Moq;
using NUnit.Framework;
using System;

namespace Outside.Training.AdvancedTddSample.Tests
{
    [TestFixture]
    public class PageVisitForwarderShould
    {
        private PageVisitForwarder _pageVisitForwarder;
        private Mock<IServiceBusMessageSender> _serviceBusMock;
        private Mock<IPageVisitToBrokeredMessageParser> _messageParserMock;

        [SetUp]
        public void BeforeEachTest()
        {
            _messageParserMock = new Mock<IPageVisitToBrokeredMessageParser>();
            _serviceBusMock = new Mock<IServiceBusMessageSender>();
            _pageVisitForwarder = new PageVisitForwarder(_messageParserMock.Object, _serviceBusMock.Object);
        }

        [Test]
        public void Throw_When_PageVisit_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => _pageVisitForwarder.ForwardMessage(null));

            _serviceBusMock.Verify(p => p.SendMessage(It.IsAny<BrokeredMessage>()), Times.Never);
        }

        [Test]
        public void Throw_When_PageUrl_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => _pageVisitForwarder.ForwardMessage(new PageVisit()));

            _serviceBusMock.Verify(p => p.SendMessage(It.IsAny<BrokeredMessage>()), Times.Never);
        }

        [Test]
        public void Call_Message_Parser()
        {
            PageVisit pageVisit = GetValidPageVisit();

            _pageVisitForwarder.ForwardMessage(pageVisit);

            _messageParserMock.Verify(p => p.Parse(pageVisit), Times.Once);
        }

        private static PageVisit GetValidPageVisit()
        {
            var pageVisit = new PageVisit();
            pageVisit.PageUrl = "test";
            return pageVisit;
        }

        [Test]
        public void Call_Message_Sender()
        {
            var expectedBrokeredMessage = new BrokeredMessage();
            var pageVisit = GetValidPageVisit();
            _messageParserMock.Setup(p => p.Parse(It.IsAny<PageVisit>()))
                .Returns(expectedBrokeredMessage);
            
            _pageVisitForwarder.ForwardMessage(pageVisit);

            _serviceBusMock.Verify(p => p.SendMessage(expectedBrokeredMessage), Times.Once);
        }
    }
}
