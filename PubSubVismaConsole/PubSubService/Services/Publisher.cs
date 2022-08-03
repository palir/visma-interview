// --------------------------------------------------------------------------------------------------------------------
//  file: Publisher.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

using Ardalis.GuardClauses;
using PubSubService.DataClasses;
using PubSubService.Interfaces;

namespace PubSubService.Services
{
    public class Publisher : IPublisher
    {
        private readonly IMessageBroker messageBroker;
        public Publisher(IMessageBroker messageBroker)
        {
            Guard.Against.Null(messageBroker, nameof(messageBroker));

            this.messageBroker = messageBroker;
        }

        public void Publish<T>(Message<T> message) where T : MessageData
        {
            Guard.Against.Null(message, nameof(message));

            messageBroker.SendMessage(message);
        }
    }
}
