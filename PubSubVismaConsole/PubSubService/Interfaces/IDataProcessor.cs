// --------------------------------------------------------------------------------------------------------------------
//  file: IDataProcessor.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

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
