using WebAppWeather.Models.Weather.Data.Current;
using WebAppWeather.Models.Weather.Data.Forecast;
using WebAppWeather.Models.Weather.View.Current;
using WebAppWeather.Models.Weather.View.Forecast;

namespace WebAppWeather.Services
{
    public class WeatherConvert
    {
        public CurrentWeatherView CurrentWeatherConvert(CurrentWeather currentWeather)
        {
            var wind = currentWeather.Wind;
            var main = currentWeather.Main;
            var clouds = currentWeather.Clouds.All;
            var icon = currentWeather.Weather.First().Icon;
            var name = currentWeather.Weather.First().Name;
            var city = currentWeather.Name;
            var datetime = currentWeather.DateTimeUtc;
            var timezone = currentWeather.TimeZone;
            var currnetDateTime = DateTimeOffset.FromUnixTimeSeconds(datetime + timezone).DateTime;
            var sunrise = DateTimeOffset.FromUnixTimeSeconds(currentWeather.System.SunriseUtc + timezone).DateTime;
            var sunset = DateTimeOffset.FromUnixTimeSeconds(currentWeather.System.SunsetUtc + timezone).DateTime;
            var id = currentWeather.Id;

            var windView = new Models.Weather.View.Wind((int)wind.Speed, wind.Degrees, wind.WindType, wind.Direction);
            var mainView = new Models.Weather.View.Main()
            {
                Temperature = (int)main.Temperature,
                TemperatureMax = (int)main.TemperatureMax,
                TemperatureMin = (int)main.TemperatureMin,
                Humidity = main.Humidity,
                FeelsLike = (int)main.FeelsLike,
                Pressure = main.Pressure
            };
            var Weather = new Models.Weather.View.Weather()
            {
                Wind = windView,
                Main = mainView,
                Clouds = clouds,
                Icon = icon,
                WeatherName = name,
            };
            var currentWeatherView = new CurrentWeatherView()
            {
                Weather = Weather,
                CityName = city,
                DateTime = currnetDateTime,
                TimeString = currnetDateTime.ToString("HH:mm"),
                DateString = currnetDateTime.ToString("M"),
                Sunrise = sunrise,
                Sunset = sunset,
                Id = id
            };

            return currentWeatherView;
        }

        public WeatherForecastView WeatherForecastConvert(Rootobject weatherForecast)
        {
            return new WeatherForecastView();
        }
    }
}
