namespace PubSubService.DataClasses
{
    public class Weather : MessageData
    {
        public float AirTemperature  { get; set; }
        public string Description { get; set; } = null;

        public override string ToString()
        {
            return $"Temperature: {AirTemperature} Description: {Description}";
        }
    }
}