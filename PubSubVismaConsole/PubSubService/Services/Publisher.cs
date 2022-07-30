using PubSubService.DataClasses;
using PubSubService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Services
{
    public class Publisher : IPublisher
    {
        private readonly IMessageBroker messageBroker;
        public Publisher(IMessageBroker messageBroker)
        {
            this.messageBroker = messageBroker;
        }

        public void Publish<T>(Message<T> message) where T : class
        {
            messageBroker.QueueMessage(message);
        }
    }
}
