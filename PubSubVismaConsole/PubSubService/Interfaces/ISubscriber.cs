using PubSubService.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
