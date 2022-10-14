using Newtonsoft.Json;

namespace WebAppWeather.Models.Weather.Data.Forecast
{

    public class WarherList
    {
        [JsonProperty(PropertyName = "dt")]
        public int Dt { get; set; }
        [JsonProperty(PropertyName = "main")]
        public Main Main { get; set; }
        [JsonProperty(PropertyName = "weather")]
        public Weather[] Weather { get; set; }
        [JsonProperty(PropertyName = "clouds")]
        public Clouds Clouds { get; set; }
        [JsonProperty(PropertyName = "wind")]
        public Wind Wind { get; set; }
    }
}
