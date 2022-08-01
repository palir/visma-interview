using Ardalis.GuardClauses;
using Microsoft.Extensions.Logging;
using PubSubService.DataClasses;
using PubSubService.Exceptions;
using PubSubService.Interfaces;

namespace PubSubService.Services
{
    public class MessageBroker : IMessageBroker
    {
        ILogger logger;

        private readonly Dictionary<Type, List<ISubscription>> channelSubscriptions = new Dictionary<Type, List<ISubscription>>();
        private readonly Dictionary<Type, IDataProcessor> processors = new Dictionary<Type, IDataProcessor>();

        public MessageBroker(ILogger logger)
        {
            this.logger = logger;
        }

        public void SendMessage<T>(Message<T> message) where T : MessageData
        {
            logger.LogInformation($"Sending {typeof(T).Name} message");

            Guard.Against.Null(message, nameof(message));

            foreach (ISubscription subscription in channelSubscriptions[typeof(T)])
            {
                //TODO: in real world scenario there should be a queue here, that would hold messages
                // as not all subscribers might consume them immediately
                
                T dataToSend = message.Data;

                if (processors.TryGetValue(typeof(T), out IDataProcessor? processor))
                {
                    try
                    {
                        dataToSend = ((IDataProcessor<T>)processor).ProcessData(message.Data);

                    }catch(Exception ex)
                    {
                        logger.LogError("Error during data processing");
                        throw new DataProcessingException(ex); 
                    }
                }

                try
                {
                    ((ISubscription<T>)subscription).ConsumeData(dataToSend);
                }
                catch (Exception ex)
                {
                    logger.LogError("Error during data transport");
                    throw new DataTransportException(ex);
                }

                logger.LogInformation($"Message {typeof(T).Name} sucessfuly sent");
            }
        }

        public void Subscribe<T>(ISubscription<T> subscription) where T : MessageData
        {
            Guard.Against.Null(subscription, nameof(subscription));

            logger.LogInformation($"Registering subscription {subscription.Name} from subscriber: {subscription.SubscriberName} ");

            if (channelSubscriptions.ContainsKey(typeof(T)))
            {
                if (channelSubscriptions[typeof(T)].ToList()
                    .Any(existSubscr => existSubscr.Name == subscription.Name && existSubscr.SubscriberName == subscription.SubscriberName))
                {
                    throw new SubscriptionException($"Subscription: {subscription.Name} for subscriber: {subscription.SubscriberName} already exists!");
                }

                try
                {
                    channelSubscriptions[typeof(T)].Add(subscription);
                }
                catch (Exception ex)
                {
                    logger.LogError("Registering a subscription failed");
                    throw new SubscriptionException(ex);
                }
            }
            else
            {
                try
                {
                    channelSubscriptions.Add(typeof(T), new List<ISubscription>() { subscription });
                }
                catch (Exception ex)
                {
                    logger.LogError("Registering a subscription failed");
                    throw new SubscriptionException(ex);
                }
            }

            logger.LogInformation($"Subscription {subscription.Name} from subscriber: {subscription.SubscriberName} sucessfuly registered");
        }

        public void AddDataProcessor<T>(IDataProcessor<T> processor) where T : MessageData
        {
            Guard.Against.Null(processor, nameof(processor));

            logger.LogInformation($"Adding data processor for channel {typeof(T).Name}");

            try
            {
                processors.Add(typeof(T), processor);

            }catch(Exception ex)
            {
                logger.LogError("Adding a processor failed");
                throw new DataProcessingException(ex);
            }

            logger.LogInformation($"Data processor for channel {typeof(T).Name} sucessfuly added");
        }
    }
}
