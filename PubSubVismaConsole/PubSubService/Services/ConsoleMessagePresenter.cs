using PubSubService.DataClasses;
using PubSubService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Services
{
    public class ConsoleMessagePresenter : IMessagePresenter
    {
        public void PresentData<T>(string subscriberName, T messageData) where T : class
        {
            Console.WriteLine($"SubscriberName: {subscriberName} Message: {messageData.ToString()}");
        }
    }
}