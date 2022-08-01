using PubSubService.DataClasses;

namespace PubSubService.Interfaces
{
    /// <summary>
    /// The subscription interface base
    /// </summary>
    public interface ISubscription
    {
        public string? Name { get; }
        public string? SubscriberName { get; }
    }

    /// <summary>
    /// Generic typed subscription interface
    /// </summary>
    /// <typeparam name="T">The channel (data) type</typeparam>
    public interface ISubscription<T> : ISubscription where T : MessageData
    { 
        /// <summary>
        /// Consumes the data sent
        /// </summary>
        /// <param name="data">The data to consume</param>
        void ConsumeData(T data);
    }
}
