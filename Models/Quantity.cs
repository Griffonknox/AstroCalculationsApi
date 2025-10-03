using System.Text.Json.Serialization;
using AstroCalculationsApi.Enums;

namespace AstroCalculationsApi.Models
{
    public class Quantity
    {
        public double Value { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PhysicalUnit Unit { get; set; }
    }
}
