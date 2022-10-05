using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WebAppWeather.Models.Weather
{
    public class CurrentWeather
    {
        public CurrentWeather()
        {

        }

        [JsonProperty(PropertyName = "weather")]
        public IEnumerable<Weather> Weather { get; set; }
        [JsonProperty(PropertyName = "main")]
        public Main Main { get; set; }
        [JsonProperty(PropertyName = "visibility")]
        public int Visibility { get; set; }
        [JsonProperty(PropertyName = "wind")]
        public Wind Wind { get; set; }
        [JsonProperty(PropertyName = "clouds")]
        public Clouds Clouds { get; set; }
        [JsonProperty(PropertyName = "dt")]
        public int DateTimeUtc { get; set; }
        [JsonProperty(PropertyName = "sys")]
        public System System { get; set; }
        [JsonProperty(PropertyName = "timezone")]
        public int TimeZone { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
