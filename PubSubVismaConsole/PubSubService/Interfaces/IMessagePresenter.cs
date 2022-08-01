using PubSubService.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
