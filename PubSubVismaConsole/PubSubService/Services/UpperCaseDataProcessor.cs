// --------------------------------------------------------------------------------------------------------------------
//  file: UpperCaseDataProcessor.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

using Ardalis.GuardClauses;
using PubSubService.DataClasses;
using PubSubService.Interfaces;

namespace PubSubService.Services
{
    public class UpperCaseDataProcessor<T> : IDataProcessor<T> where T : MessageData
    {
        public T ProcessData(T data)
        {
            Guard.Against.Null(data, nameof(data));

            foreach (var prop in data.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(string))
                {
                    prop.SetValue(data, ((string?)prop.GetValue(data))?.ToUpper());
                }
            }
            return data;
        }
    }
}
