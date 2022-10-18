using System;
using WebAppWeather.Models.Weather.Data;
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
            var weather = currentWeather.Weather.ElementAt(0);
            var wind = currentWeather.Wind;
            var main = currentWeather.Main;
            var clouds = currentWeather.Clouds;
            var city = currentWeather.Name;
            var datetime = currentWeather.DateTimeUtc;
            var timezone = currentWeather.TimeZone;
            var currnetDateTime = DateTimeOffset.FromUnixTimeSeconds(datetime + timezone).DateTime;
            var sunrise = DateTimeOffset.FromUnixTimeSeconds(currentWeather.System.SunriseUtc + timezone).DateTime;
            var sunset = DateTimeOffset.FromUnixTimeSeconds(currentWeather.System.SunsetUtc + timezone).DateTime;
            var id = currentWeather.Id;

            var Weather = ConvertWeather(weather, clouds, main, wind);
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
            var list = weatherForecast.WarherList;
            var listView = new List<Models.Weather.View.Forecast.WeatherForecast>();
            var daysForecast = new List<DayForecast>();

            for (int i = 0; i < list.Length; i++)
            {
                var item = list.ElementAt(i);
                string date = DateTimeOffset.FromUnixTimeSeconds(item.Dt).DateTime.ToString("H:mm dd MMMM");
                listView.Add(ConvertWeather(item.Weather.ElementAt(0), item.Clouds, item.Main, item.Wind, date));

                if (i == 6 || i == 14 || i == 22 || i == 30 || i == 38)
                {
                    var wind = new Models.Weather.View.Wind((int)list[i].Wind.Speed,
                                                            (int)list[i].Wind.Degrees,
                                                            list[i].Wind.WindType,
                                                            list[i].Wind.Direction);

                    daysForecast.Add(new DayForecast(DateTimeOffset.FromUnixTimeSeconds(list[i].Dt).DateTime.ToString("ddd"),
                                                     list[i].Weather.ElementAt(0).Name,
                                                     DateTimeOffset.FromUnixTimeSeconds(list[i].Dt).DateTime.ToString("M"),
                                                     list[i].Weather.ElementAt(0).Icon,
                                                     (int)list[i].Main.TemperatureMax,
                                                     (int)list[i].Main.TemperatureMin,
                                                     (int)list[i].Main.Temperature,
                                                     (int)list[i].Main.FeelsLike,
                                                     (int)list[i].Main.Humidity,
                                                     (int)list[i].Main.Pressure,
                                                     wind));
                }
            }

            var weatherForecastView = new WeatherForecastView()
            {
                Weathers = listView,
                DaysForecasts = daysForecast
            };

            return weatherForecastView;
        }

        private Models.Weather.View.Main ConvertMain(Models.Weather.Data.Main main)
        {
            var mainView = new Models.Weather.View.Main()
            {
                Temperature = (int)main.Temperature,
                TemperatureMax = (int)main.TemperatureMax,
                TemperatureMin = (int)main.TemperatureMin,
                Humidity = main.Humidity,
                FeelsLike = (int)main.FeelsLike,
                Pressure = main.Pressure
            };

            return mainView;
        }

        private Models.Weather.View.Weather ConvertWeather(Models.Weather.Data.Weather weather,
                                                           Clouds clouds,
                                                           Models.Weather.Data.Main main,
                                                           Models.Weather.Data.Wind wind)
        {
            var weatherView = new Models.Weather.View.Weather(weather.Name,
                                                              ConvertMain(main),
                                                              ConvertWind(wind),
                                                              clouds.All,
                                                              weather.Icon);

            return weatherView;
        }

        private Models.Weather.View.Forecast.WeatherForecast ConvertWeather(Models.Weather.Data.Weather weather,
                                                            Clouds clouds,
                                                            Models.Weather.Data.Main main,
                                                             Models.Weather.Data.Wind wind,
                                                             string date)
        {
            var weatherView = new Models.Weather.View.Forecast.WeatherForecast(weather.Name,
                                                              ConvertMain(main),
                                                              ConvertWind(wind),
                                                              clouds.All,
                                                              weather.Icon, 
                                                              date);

            return weatherView;
        }

        private Models.Weather.View.Wind ConvertWind(Models.Weather.Data.Wind wind)
        {
            var windView = new Models.Weather.View.Wind((int)wind.Speed, wind.Degrees, wind.WindType, wind.Direction);

            return windView;
        }
    }
}
