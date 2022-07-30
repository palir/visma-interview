using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Interfaces
{
    public interface ISubscriber
    {
        void Subscribe<T>() where T : class;
    }
}
