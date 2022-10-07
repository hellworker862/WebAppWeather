using Newtonsoft.Json;

namespace WebAppWeather.Models.Weather
{
    public class Clouds
    {
        public Clouds()
        {

        }

        [JsonProperty(PropertyName = "all")]
        public int All { get; set; }
    }
}
