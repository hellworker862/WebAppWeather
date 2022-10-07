using Newtonsoft.Json;

namespace WebAppWeather.Models.Weather
{
    public class System
    {
        public System()
        {

        }

        [JsonProperty(PropertyName = "sunrise")]
        public int SunriseUtc { get; set; }
        [JsonProperty(PropertyName = "sunset")]
        public int SunsetUtc { get; set; }
    }
}
