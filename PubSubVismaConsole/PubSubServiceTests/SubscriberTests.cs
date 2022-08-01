using NSubstitute;
using PubSubService.DataClasses;
using PubSubService.Exceptions;
using PubSubService.Interfaces;
using PubSubService.Services;

namespace PubSubServiceTests
{
    public class SubscriberTests
    {
        private const string subscriberName = "test subsciber";

        private DelegateBasedSubscriber target;
        IMessageBroker messageBroker;
        IMessagePresenter messagePresenter;

        [SetUp]
        public void Setup()
        {
            this.messageBroker = Substitute.For<IMessageBroker>();
            this.messagePresenter = Substitute.For<IMessagePresenter>();
            target = new DelegateBasedSubscriber(subscriberName, this.messageBroker, this.messagePresenter);
        }

        [Test]
        public void Subscribe_ValidMessage_CallsSubscribeOnBroker()
        {
            // Arrange
            Message<Weather> message = new Message<Weather>(FakeData.Weather);

            // Act
            this.target.Subscribe<Weather>();

            // Assert
            this.messageBroker.Received(1).Subscribe<Weather>(Arg.Is<Subscription<Weather>>(
                sub => sub.SubscriberName == subscriberName &&
                       sub.Name == typeof(Weather).Name));
        }

        [Test]
        public void Subscribe_AlreadyExistsSubscription_ThrowsSubscriptionException()
        {
            // Arrange
            target.Subscribe<Weather>();

            // Act
            var ex = Assert.Throws<SubscriptionException>(delegate { this.target.Subscribe<Weather>(); });

            // Assert
            Assert.That(ex, Is.Not.Null, "Exception was null");
        }
    }
}
