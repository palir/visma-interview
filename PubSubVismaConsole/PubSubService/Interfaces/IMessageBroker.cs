using PubSubService.DataClasses;
using PubSubService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Interfaces
{
    public interface IMessageBroker
    {
        void AddDataProcessor<T>(IDataProcessor<T> processor) where T : class;
        void QueueMessage<T>(Message<T> message) where T : class;
        void Subscribe<T>(MessageBroker.PostDataDelegate<T> subscriber);
    }
}
