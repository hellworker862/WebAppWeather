using Newtonsoft.Json;

namespace WebAppWeather.Models.Weather
{
    public class Main
    {
        public Main()
        {

        }

        [JsonProperty(PropertyName = "temp")]
        public float Temperature { get; set; }
        [JsonProperty(PropertyName = "feels_like")]
        public float FeelsLike { get; set; }
        [JsonProperty(PropertyName = "temp_min")]
        public float TemperatureMin { get; set; }
        [JsonProperty(PropertyName = "temp_max")]
        public float TemperatureMax { get; set; }
        [JsonProperty(PropertyName = "pressure")]
        public int Pressure { get; set; }
        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get; set; }
    }
}
