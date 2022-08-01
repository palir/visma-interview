using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Exceptions
{
    /// <summary>
    /// Represents an exception indicating data processing error
    /// </summary>
    public class DataProcessingException : Exception
    {
        public DataProcessingException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }

        public DataProcessingException(string message, Exception? innerException = null) 
            : base(message, innerException)
        {
        }
    }
}
