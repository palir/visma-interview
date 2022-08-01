using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Exceptions
{
    /// <summary>
    /// Represents an exception indicating a registering subscription error
    /// </summary>
    public class SubscriptionException : Exception
    {
        public SubscriptionException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }
        public SubscriptionException(string message, Exception? innerException = null) 
            : base(message, innerException)
        {
        }
    }
}
