using Ardalis.GuardClauses;
using PubSubService.DataClasses;
using PubSubService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Services
{
    public class DelegateBasedSubsription<T> : Subscription<T>, ISubscription<T> where T : MessageData
    {
        public delegate void PostDataDelegate(T item);
        PostDataDelegate target;

        public DelegateBasedSubsription(string name, string subscriberName, PostDataDelegate target) 
            : base(name, subscriberName)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.Null(target, nameof(target));

            this.target = target;
        }

        public override void ConsumeData(T data) 
        {
            target(data);
        }
    }
}