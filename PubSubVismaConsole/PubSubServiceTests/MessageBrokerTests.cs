using Microsoft.Extensions.Logging;
using NSubstitute;
using PubSubService.DataClasses;
using PubSubService.Exceptions;
using PubSubService.Interfaces;
using PubSubService.Services;

namespace PubSubServiceTests
{
    public class MessageBrokerTests
    {
        private const string subscriberName = "test subsciber";
        private const string subscriberName2 = "test subsciber2";

        private MessageBroker target;
        IMessagePresenter messagePresenter;
        ILogger logger;

        [SetUp]
        public void Setup()
        {
            this.messagePresenter = Substitute.For<IMessagePresenter>();
            this.logger = Substitute.For<ILogger>();
            this.target = new MessageBroker(this.logger);
        }

        [Test]
        public void SendMessage_ValidMessage_CallsConsumeDataOnAllChannelSubscriptions()
        {
            // Arrange
            Message<Weather> weatherMessage = new Message<Weather>(FakeData.Weather);

            Subscription<Weather> subscr1 = Substitute.For<Subscription<Weather>>(typeof(Weather).Name, subscriberName);
            Subscription<Weather> subscr2 = Substitute.For<Subscription<Weather>>(typeof(Weather).Name, subscriberName2);

            this.target.Subscribe(subscr1);
            this.target.Subscribe(subscr2);

            // Act
            this.target.SendMessage<Weather>(weatherMessage);

            // Assert
            subscr1.Received(1).ConsumeData(weatherMessage.Data);
            subscr2.Received(1).ConsumeData(weatherMessage.Data);
        }

        [Test]
        public void Subscribe_DataProcessorExists_CallsProcessData()
        {
            // Arrange
            Message<Weather> weatherMessage = new Message<Weather>(FakeData.Weather);

            DelegateBasedSubscriber subscriber1 = new DelegateBasedSubscriber(subscriberName, target, messagePresenter);
            subscriber1.Subscribe<Weather>();

            IDataProcessor<Weather> dataProcessor = Substitute.For<IDataProcessor<Weather>>();
            dataProcessor.ProcessData(weatherMessage.Data).Returns(weatherMessage.Data);

            this.target.AddDataProcessor<Weather>(dataProcessor);

            // Act
            this.target.SendMessage<Weather>(weatherMessage);

            // Assert
            dataProcessor.Received(1).ProcessData(weatherMessage.Data);
        }
    }
}
