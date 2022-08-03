// --------------------------------------------------------------------------------------------------------------------
//  file: Subscription.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

using PubSubService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.DataClasses
{
    public abstract class Subscription
    {
        public string? Name { get; }
        public string? SubscriberName { get; }

        protected Subscription(string name, string subscriberName)
        {
            this.Name = name;
            this.SubscriberName = subscriberName;
        }
    }

    public abstract class Subscription<T> : Subscription, ISubscription<T> where T : MessageData
    {
        protected Subscription(string name, string subscriberName) : base(name, subscriberName)
        {
        }
        public virtual void ConsumeData(T data)
        {
        }
    }
}
