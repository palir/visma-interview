using PubSubService.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Interfaces
{
    public interface ISubscription
    {
    }

    public interface ISubscription<T> : ISubscription where T : MessageData
    {
        void ConsumeData(T data);
    }
}
