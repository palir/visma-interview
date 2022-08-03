// --------------------------------------------------------------------------------------------------------------------
//  file: DataProcessingException.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

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
