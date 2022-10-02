using System.Text.Json.Serialization;

namespace WebAppWeather.Models.Weather
{
    public class Weather
    {
        public Weather()
        {

        }

        [JsonPropertyName("main")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}
