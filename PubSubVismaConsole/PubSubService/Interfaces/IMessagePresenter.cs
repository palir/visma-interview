// --------------------------------------------------------------------------------------------------------------------
//  file: SubscriptionException.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

using PubSubService.DataClasses;

namespace PubSubService.Interfaces
{
    /// <summary>
    /// The message presenter interface
    /// </summary>
    public interface IMessagePresenter
    {
        /// <summary>
        /// Presents (displays) the data
        /// </summary>
        /// <typeparam name="T">The data type.</typeparam>
        /// <param name="subscriberName">The subscriber name.</param>
        /// <param name="messageData">The data to present.</param>
        public void PresentData<T>(string subscriberName, T messageData) where T : MessageData;
    }
}
