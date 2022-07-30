using NSubstitute;
using PubSubService.Interfaces;
using PubSubService.Services;

namespace PubSubServiceTests
{
    public class Tests
    {
        private Publisher target;
        IMessageBroker messagebroker;

        [SetUp]
        public void Setup()
        {
            this.messagebroker = Substitute.For<IMessageBroker>();
            target = new Publisher(this.messagebroker);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}