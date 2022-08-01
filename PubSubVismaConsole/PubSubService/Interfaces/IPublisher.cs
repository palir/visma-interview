using PubSubService.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
