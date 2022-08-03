// --------------------------------------------------------------------------------------------------------------------
//  file: CultureEvent.cs
//  description: Created for the purpose of an job apply interview  8/2022
//  author: Pavol Raska 
//  --------------------------------------------------------------------------------------------------------------------

namespace PubSubService.DataClasses
{
    public class CultureEvent : MessageData
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
