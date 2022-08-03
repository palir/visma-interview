// --------------------------------------------------------------------------------------------------------------------
//  file: IPublisher.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

using PubSubService.DataClasses;

namespace PubSubService.Interfaces
{
    /// <summary>
    /// The publisher interface
    /// </summary>
    public interface IPublisher
    {
        /// <summary>
        /// Publishes the data
        /// </summary>
        /// <typeparam name="T">The data type.</typeparam>
        /// <param name="message">The data to publish.</param>
        void Publish<T>(Message<T> message) where T : MessageData;
    }
}
