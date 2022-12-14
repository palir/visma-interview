// --------------------------------------------------------------------------------------------------------------------
//  file: PublisherTests.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

using NSubstitute;
using PubSubService.DataClasses;
using PubSubService.Interfaces;
using PubSubService.Services;

namespace PubSubServiceTests
{
    public class PublisherTests
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
        public void Publish_NullMessage_ThrowsException()
        {
            // Arrange

            // Act
            var ex = Assert.Throws<ArgumentNullException>(delegate { this.target.Publish<Weather>((Message<Weather>)null); });


            // Assert
            Assert.That(ex, Is.Not.Null, "Exception was null");
            Assert.That(ex.Message, Does.Contain("message"), "Expected parameter name not returned in error");
        }

        [Test]
        public void Publish_ValidMessage_CallsSendOnBroker()
        {
            // Arrange
            Message<Weather> message = new Message<Weather>(FakeData.Weather);

            // Act
            this.target.Publish<Weather>(message);

            // Assert
            this.messagebroker.Received(1).SendMessage<Weather>(message);
        }
    }
}
