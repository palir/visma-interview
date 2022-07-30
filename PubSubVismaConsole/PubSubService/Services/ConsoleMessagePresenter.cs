using Ardalis.GuardClauses;
using PubSubService.DataClasses;
using PubSubService.Interfaces;

namespace PubSubService.Services
{
    public class ConsoleMessagePresenter : IMessagePresenter
    {
        public void PresentData<T>(string subscriberName, T messageData) where T : MessageData
        {
            Guard.Against.NullOrWhiteSpace(subscriberName, nameof(subscriberName));
            Guard.Against.Null(messageData, nameof(messageData));

            Console.WriteLine($"SubscriberName: {subscriberName} Message: {messageData.ToString()}");
        }
    }
}