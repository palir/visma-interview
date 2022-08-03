// --------------------------------------------------------------------------------------------------------------------
//  file: DataTransportException.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

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
