// --------------------------------------------------------------------------------------------------------------------
//  file: DelegateBasedSubscriber.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

using Ardalis.GuardClauses;
using PubSubService.DataClasses;
using PubSubService.Interfaces;

namespace PubSubService.Services
{
    public class DelegateBasedSubscriber : ISubscriber 
    {
        private readonly string name;
        private readonly IMessageBroker broker;
        private readonly IMessagePresenter presenter;

        public DelegateBasedSubscriber(string name, IMessageBroker messageBroker, IMessagePresenter presenter)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.Null(messageBroker, nameof(messageBroker));
            Guard.Against.Null(presenter, nameof(presenter));

            this.name = name;
            this.broker = messageBroker;
            this.presenter = presenter;
        }
        public ISubscription<T> Subscribe<T>() where T : MessageData
        {
            DelegateBasedSubsription<T> subscr = new DelegateBasedSubsription<T>($"{typeof(T).Name}", name, OnGetMessage<T>);
            
            broker.Subscribe<T>(subscr);

            return subscr;
        }

        void OnGetMessage<T>(T message) where T : MessageData
        {
            Guard.Against.Null(message, nameof(message));

            presenter.PresentData(name, message);
        }
    }
}
