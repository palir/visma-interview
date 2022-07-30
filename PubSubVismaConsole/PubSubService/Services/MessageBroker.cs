using Ardalis.GuardClauses;
using PubSubService.DataClasses;
using PubSubService.Interfaces;

namespace PubSubService.Services
{
    public class MessageBroker : IMessageBroker
    {
        Dictionary<Type, List<Subscription>> channelSubscriptions = new Dictionary<Type, List<Subscription>>();
        Dictionary<Type, IDataProcessor> processors = new Dictionary<Type, IDataProcessor>();

        public void SendMessage<T>(Message<T> message) where T : MessageData
        {
            Guard.Against.Null(message, nameof(message));

            foreach (ISubscription subscription in channelSubscriptions[typeof(T)])
            {
                //TODO: in real world scenario there should be a queue here, that would hold messages
                // as not all subscribers might consume them immediately
                
                T dataToSend = message.Data;

                if (processors.TryGetValue(typeof(T), out IDataProcessor? processor))
                {
                    dataToSend = ((IDataProcessor<T>)processor).ProcessData(message.Data);
                }

                ((ISubscription<T>)subscription).ConsumeData(dataToSend);
            }
        }

        public void Subscribe<T>(Subscription<T> subscription) where T : MessageData
        {
            Guard.Against.Null(subscription, nameof(subscription));

            if (channelSubscriptions.ContainsKey(typeof(T)))
            {
                if (channelSubscriptions[typeof(T)].ToList()
                    .Any(existSubscr => existSubscr.Name == subscription.Name && existSubscr.SubscriberName == subscription.SubscriberName))
                {
                    throw new Exception($"Subscription: {subscription.Name} for subscriber: {subscription.SubscriberName} already exists!");
                }

                channelSubscriptions.Add(typeof(T), new List<Subscription>() { subscription });
            }
            else
            {
                channelSubscriptions[typeof(T)].Add(subscription);
            }
        }

        public void AddDataProcessor<T>(IDataProcessor<T> processor) where T : MessageData
        {
            Guard.Against.Null(processor, nameof(processor));

            processors.Add(typeof(T), processor);
        }
    }
}