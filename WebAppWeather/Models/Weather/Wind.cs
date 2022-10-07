using Newtonsoft.Json;

namespace WebAppWeather.Models.Weather
{
    public class Wind
    {
        public Wind()
        {

        }

        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }
        [JsonProperty(PropertyName = "deg")]
        public int Degrees { get; set; }
        [JsonProperty(PropertyName = "gust")]
        public double Gust { get; set; }
    }
}
