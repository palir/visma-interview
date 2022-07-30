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
