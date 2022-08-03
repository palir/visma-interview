// --------------------------------------------------------------------------------------------------------------------
//  file: ConsoleMessagePresenter.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

using Ardalis.GuardClauses;
using PubSubService.DataClasses;
using PubSubService.Interfaces;

namespace PubSubService.Services
{
    public class ConsoleMessagePresenter : IMessagePresenter
    {
        public void PresentData<T>(string subscriberName, T messageData) where T : MessageData
        {
            Guard.Against.NullOrWhiteSpace(subscriberName, nameof(subscriberName));
            Guard.Against.Null(messageData, nameof(messageData));

            Console.WriteLine();
            Console.WriteLine($"//-------------------------------------------------------");
            Console.WriteLine($"// SubscriberName: {subscriberName} received message:");
            Console.WriteLine($"{messageData.ToString()}");
            Console.WriteLine($"//-------------------------------------------------------");
            Console.WriteLine();
        }
    }
}
