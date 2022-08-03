// --------------------------------------------------------------------------------------------------------------------
//  file: Weather.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

namespace PubSubService.DataClasses
{
    public class Weather : MessageData
    {
        public float AirTemperature  { get; set; }
        public string? Description { get; set; } = null;

        public override string ToString()
        {
            return $"Temperature: {AirTemperature} Description: {Description}";
        }
    }
}
