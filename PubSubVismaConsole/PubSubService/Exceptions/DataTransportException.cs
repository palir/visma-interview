using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Exceptions
{
    /// <summary>
    /// Represents an exception indicating data transport error
    /// </summary>
    public class DataTransportException : Exception
    {
        public DataTransportException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }
        public DataTransportException(string message, Exception? innerException = null) 
            : base(message, innerException)
        {
        }
    }
}
