using PubSubService.DataClasses;
using PubSubService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Services
{
    public class Subscriber : ISubscriber 
    {
        private readonly string name;
        private readonly IMessageBroker broker;
        private readonly IMessagePresenter presenter;

        public Subscriber(string name, IMessageBroker broker, IMessagePresenter presenter)
        {
            this.name = name;
            this.broker = broker;
            this.presenter = presenter;
        }
        public void Subscribe<T>() where T : class
        {
            broker.Subscribe<T>(OnGetMessage);
        }

        void OnGetMessage<T>(T message) where T : class
        {
            presenter.PresentData(name, message);
        }
    }
}
