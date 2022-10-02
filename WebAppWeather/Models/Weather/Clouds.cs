using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WebAppWeather.Models.Weather
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
