using System.Text.Json.Serialization;

namespace WebAppWeather.Models.Weather
{
    public class Clouds
    {
        public Clouds()
        {

        }
        [JsonPropertyName("all")]
        public int All { get; set; }
    }
}
