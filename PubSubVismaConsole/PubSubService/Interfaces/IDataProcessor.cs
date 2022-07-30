using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Interfaces
{
    public interface IDataProcessor
    {
    }

    public interface IDataProcessor<T> : IDataProcessor where T: class 
    {
        T ProcessData(T data);
    }
}
