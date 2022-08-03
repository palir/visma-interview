// --------------------------------------------------------------------------------------------------------------------
//  file: Message.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

namespace PubSubService.DataClasses
{
    public class Message<T> 
        where T: class
    {
        public Message(T data)
        {
            this.Data = data;
        }

        public DateTime CreatedAt { get; } = DateTime.Now;

        public T Data { get; }
    }
}
