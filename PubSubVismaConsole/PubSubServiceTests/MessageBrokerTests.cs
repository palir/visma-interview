// --------------------------------------------------------------------------------------------------------------------
//  file: MessageBrokerTests.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

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
        public void SendMessage_DataProcessorExists_CallsProcessData()
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

        [Test]
        public void SendMessage_DataProcessorExists_CallsConsumeDataWithModifiedData()
        {
            // Arrange
            Message<Weather> weatherMessage = new Message<Weather>(FakeData.Weather);
            Weather modifiedData = new Weather() { AirTemperature = 18, Description = weatherMessage.Data.Description.ToUpper() };

            IDataProcessor<Weather> dataProcessor = Substitute.For<IDataProcessor<Weather>>();
            dataProcessor.ProcessData(weatherMessage.Data).Returns(modifiedData);

            Subscription<Weather> subscr1 = Substitute.For<Subscription<Weather>>(typeof(Weather).Name, subscriberName);

            this.target.Subscribe(subscr1);

            this.target.AddDataProcessor<Weather>(dataProcessor);

            // Act
            this.target.SendMessage<Weather>(weatherMessage);

            // Assert
            subscr1.Received(1).ConsumeData(Arg.Is<Weather>(weather => weather.AirTemperature == modifiedData.AirTemperature &&
                                                                       weather.Description == modifiedData.Description));
        }

        [Test]
        public void Subscribe_AlreadyExistsSubscription_ThrowsSubscriptionException()
        {
            // Arrange
            Message<Weather> weatherMessage = new Message<Weather>(FakeData.Weather);

            Subscription<Weather> subscr1 = Substitute.For<Subscription<Weather>>(typeof(Weather).Name, subscriberName);

            this.target.Subscribe(subscr1);

            // Act
            var ex = Assert.Throws<SubscriptionException>(delegate { this.target.Subscribe(subscr1); });

            // Assert
            Assert.That(ex, Is.Not.Null, "Exception was null");
        }
    }
}
