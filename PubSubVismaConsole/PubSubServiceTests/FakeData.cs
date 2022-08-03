// --------------------------------------------------------------------------------------------------------------------
//  file: FakeData.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

using PubSubService.DataClasses;

namespace PubSubServiceTests
{
    public class FakeData
    {
        public static DateTime StartDate => new DateTime(2022, 9, 10, 17, 0, 0);

        public static Weather Weather => new Weather()
        {
            AirTemperature = 20,
            Description = "Cloudy"
        };

        public static CultureEvent CultureEvent => new CultureEvent()
        {
            Name = "Conncert",
            Place = "Arena",
            BeginsAt = StartDate
        };
    }
}
