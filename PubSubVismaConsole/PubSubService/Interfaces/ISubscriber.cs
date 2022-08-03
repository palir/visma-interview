// --------------------------------------------------------------------------------------------------------------------
//  file: ISubscriber.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

using PubSubService.DataClasses;

namespace PubSubService.Interfaces
{
    /// <summary>
    /// The subscriber interface
    /// </summary>
    public interface ISubscriber
    {
        /// <summary>
        /// Registers the subscription
        /// </summary>
        /// <typeparam name="T">The channel type.</typeparam>
        /// <returns>The created subscription.</returns>
        ISubscription<T> Subscribe<T>() where T : MessageData;
    }
}
