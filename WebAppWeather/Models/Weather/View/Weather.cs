namespace WebAppWeather.Models.Weather.View
{
    public class Weather
    {
        public string WeatherName { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public int Clouds { get; set; }
        public string Icon { get; set; }
    }
}
