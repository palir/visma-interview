// --------------------------------------------------------------------------------------------------------------------
//  file: SubscriberTests.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

using NSubstitute;
using PubSubService.DataClasses;
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
    }
}
