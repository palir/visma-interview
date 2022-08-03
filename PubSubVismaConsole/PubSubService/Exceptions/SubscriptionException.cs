// --------------------------------------------------------------------------------------------------------------------
//  file: SubscriptionException.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

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
