using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.DataClasses
{
    public class Weather
    {
        public float AirTemperature  { get; set; }
        public string Description { get; set; } = null;

        public override string ToString()
        {
            return $"Temperature: {AirTemperature} Description: {Description}";
        }
    }
}
