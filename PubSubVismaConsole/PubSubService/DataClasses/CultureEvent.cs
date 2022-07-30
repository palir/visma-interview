using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService.DataClasses
{
    public class CultureEvent
    {
        public string? Name { get; set; }
        public string? Place { get; set; }
        public DateTime BeginsAt { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Place: {Place} When: {BeginsAt} ";
        }
    }
}
