using System.Text.Json.Serialization;

namespace WebAppWeather.Models.Weather
{
    public class Wind
    {
        public Wind()
        {

        }
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
        [JsonPropertyName("deg")]
        public int Degrees { get; set; }
        [JsonPropertyName("gust")]
        public double Gust { get; set; }
    }
}
