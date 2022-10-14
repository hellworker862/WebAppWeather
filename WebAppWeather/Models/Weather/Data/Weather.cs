using Newtonsoft.Json;

namespace WebAppWeather.Models.Weather.Data
{
    public class Weather
    {
        [JsonProperty(PropertyName = "description")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

    }
}
