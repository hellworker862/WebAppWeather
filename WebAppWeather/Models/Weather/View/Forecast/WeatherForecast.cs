namespace WebAppWeather.Models.Weather.View.Forecast
{
    public class WeatherForecast : Weather
    {
        public WeatherForecast(string weatherName, Main main, Wind wind, int clouds, string icon, string dateTimeString) : base(weatherName, main, wind, clouds, icon)
        {
            DateTimeString = dateTimeString;
        }

        public string DateTimeString { get; set; }
    }
}
