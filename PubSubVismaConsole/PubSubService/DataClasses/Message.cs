using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
