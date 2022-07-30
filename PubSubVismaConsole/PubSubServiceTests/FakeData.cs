using PubSubService.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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