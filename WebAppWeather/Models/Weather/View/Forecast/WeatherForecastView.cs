namespace WebAppWeather.Models.Weather.View.Forecast
{
    public class WeatherForecastView
    {
        public IEnumerable<DayForecast> DaysForecasts { get; set; }
        public IEnumerable<WeatherForecast> Weathers { get; set; }
    }
}
