using Newtonsoft.Json;

namespace WebAppWeather.Models.Weather.View
{
    public class Main
    {
        public int Temperature { get; set; }
        public int FeelsLike { get; set; }
        public int TemperatureMin { get; set; }
        public int TemperatureMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
}
