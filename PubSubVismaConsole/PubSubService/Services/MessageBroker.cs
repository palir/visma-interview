using PubSubService.DataClasses;
using PubSubService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Services
{
    public class MessageBroker : IMessageBroker
    {
        public delegate void PostDataDelegate<T>(T item);

        Dictionary<Type, List<Delegate>> channelSubscribers = new Dictionary<Type, List<Delegate>>();
        Dictionary<Type, IDataProcessor> processors = new Dictionary<Type, IDataProcessor>();    

        public void QueueMessage<T>(Message<T> message) where T : class
        {
            foreach(var subscriber in channelSubscribers[typeof(T)])
            {
                PostDataDelegate<T> m1 = (PostDataDelegate<T>)subscriber;

                if (processors.TryGetValue(typeof(T), out IDataProcessor? processor))
                {
                    m1(((IDataProcessor<T>)processor).ProcessData(message.Data));
                }
                else
                {
                    m1(message.Data);
                }
            }
        }

        public void Subscribe<T>(PostDataDelegate<T> subscriber)
        {
            PostDataDelegate<T> m1 = subscriber;

            if (!channelSubscribers.ContainsKey(typeof(T)))
            {
                channelSubscribers.Add(typeof(T), new List<Delegate>() { subscriber });
            }
            else
            {
                channelSubscribers[typeof(T)].Add(subscriber);
            }
        }

        public void AddDataProcessor<T>(IDataProcessor<T> processor) where T : class
        {
            processors.Add(typeof(T), processor);
        }
    }
}
