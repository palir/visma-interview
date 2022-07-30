using PubSubService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Services
{
    public class UpperCaseDataProcessor<T> : IDataProcessor<T> where T : class
    {
        public T ProcessData(T data)
        {
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
