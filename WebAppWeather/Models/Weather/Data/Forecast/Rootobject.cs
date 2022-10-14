using Newtonsoft.Json;

namespace WebAppWeather.Models.Weather.Data.Forecast
{
    public class Rootobject
    {
        [JsonProperty(PropertyName = "cod")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "message")]
        public int Message { get; set; }
        [JsonProperty(PropertyName = "cnt")]
        public int Cnt { get; set; }
        [JsonProperty(PropertyName = "list")]
        public WarherList[] WarherList { get; set; }
    }
}
