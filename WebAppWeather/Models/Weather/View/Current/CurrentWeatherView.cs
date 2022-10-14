namespace WebAppWeather.Models.Weather.View.Current
{
    public class CurrentWeatherView
    {
        public Weather Weather { get; set; }
        public DateTime DateTime { get; set; }
        public string TimeString { get; set; }
        public string DateString { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public string CityName { get; set; }
        public int Id { get; set; }
    }
}
