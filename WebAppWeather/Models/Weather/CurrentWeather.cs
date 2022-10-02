using System.Text.Json.Serialization;

namespace WebAppWeather.Models.Weather
{
    public class CurrentWeather
    {
        public CurrentWeather()
        {

        }

        [JsonPropertyName("weather")]
        public Weather Weather { get; set; }
        [JsonPropertyName("main")]
        public Main Main { get; set; }
        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }
        [JsonPropertyName("dt")]
        public long DateTimeUtc { get; set; }
        [JsonPropertyName("sys")]
        public System System { get; set; }
        [JsonPropertyName("timezone")]
        public int TimeZone { get; set; }
    }
}
