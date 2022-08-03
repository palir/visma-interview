// --------------------------------------------------------------------------------------------------------------------
//  file: IMessageBroker.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

using PubSubService.DataClasses;

namespace PubSubService.Interfaces
{
    /// <summary>
    /// A messsage broker interface
    /// </summary>
    public interface IMessageBroker
    {
        /// <summary>
        /// Add data processor
        /// </summary>
        /// <typeparam name="T">The channel type</typeparam>
        /// <param name="processor">The processor implementation</param>
        void AddDataProcessor<T>(IDataProcessor<T> processor) where T : MessageData;

        /// <summary>
        /// Sends the message to all registered subscribers in the channel
        /// </summary>
        /// <typeparam name="T">The channel type</typeparam>
        /// <param name="message"></param>
        void SendMessage<T>(Message<T> message) where T : MessageData;

        /// <summary>
        /// Registers the subscription
        /// </summary>
        /// <typeparam name="T">The channel type</typeparam>
        /// <param name="subscription">The subscription definition.</param>
        void Subscribe<T>(ISubscription<T> subscription) where T : MessageData;
    }
}
