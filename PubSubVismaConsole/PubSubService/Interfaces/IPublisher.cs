using PubSubService.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Interfaces
{
    public interface IPublisher
    {
        void Publish<T>(Message<T> message) where T : MessageData;
    }
}