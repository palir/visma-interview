using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.Interfaces
{
    /// <summary>
    /// Data processsor interface base
    /// </summary>
    public interface IDataProcessor
    {
    }

    /// <summary>
    /// Generic typed data procesor interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataProcessor<T> : IDataProcessor where T: class 
    {
        /// <summary>
        /// Transform the data in some way.
        /// </summary>
        /// <param name="data">Data to process.</param>
        /// <returns>The transformed data.</returns>
        T ProcessData(T data);
    }
}
