using Newtonsoft.Json;

namespace WebAppWeather.Models.Weather.Data
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
