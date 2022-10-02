using System.Text.Json.Serialization;

namespace WebAppWeather.Models.Weather
{
    public class System
    {
        public System()
        {

        }

        [JsonPropertyName("sunrise")]
        public long SunriseUtc { get; set; }
        [JsonPropertyName("sunset")]
        public long SunsetUtc { get; set; }
    }
}
