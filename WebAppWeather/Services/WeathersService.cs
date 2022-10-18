using Newtonsoft.Json;
using WebAppWeather.Models.Weather.Data.Current;
using WebAppWeather.Models.Weather.Data.Forecast;
using WebAppWeather.Models.Weather.View.Current;
using WebAppWeather.Models.Weather.View.Forecast;

namespace WebAppWeather.Services
{
    public class WeathersService
    {
        private const string stringHref = "https://api.openweathermap.org/data/2.5/";
        private readonly HttpClient _httpClient;
        private ApplicationContext _context;
        private IConfiguration _configuration;
        private WeatherConvert _weatherConvert;

        public WeathersService(HttpClient httpClient, ApplicationContext context, IConfiguration configuration, WeatherConvert weatherConvert)
        {
            _httpClient = httpClient;
            _context = context;
            _configuration = configuration;
            _weatherConvert = weatherConvert;
        }

        public async Task<CurrentWeatherView> GetCurrentWeather(int id)
        {
            var city = _context.Cities.FirstOrDefault(x => x.Id == id);

            if (city == null)
            {
                return null;
            }

            string apiKey = _configuration.GetValue<string>("ApiKeys:OpenWeatherMapKey");
            string stringRequest = $"weather?lat={city.Lat}&lon={city.Lon}&appid={apiKey}&lang=ru&units=metric";

            var stringTask = await _httpClient.GetStringAsync(stringHref + stringRequest);
            var weather = JsonConvert.DeserializeObject<CurrentWeather>(stringTask);

            return _weatherConvert.CurrentWeatherConvert(weather);
        }

        public async Task<WeatherForecastView> GetWeatherForecast(int id)
        {
            var city = _context.Cities.FirstOrDefault(x => x.Id == id);

            if (city == null)
            {
                return null;
            }

            string apiKey = _configuration.GetValue<string>("ApiKeys:OpenWeatherMapKey");
            string stringRequest = $"forecast?lat={city.Lat}&lon={city.Lon}&appid={apiKey}&lang=ru&units=metric";

            var stringTask = await _httpClient.GetStringAsync(stringHref + stringRequest);
            var weather = JsonConvert.DeserializeObject<Rootobject>(stringTask);

            return _weatherConvert.WeatherForecastConvert(weather);
        }
    }
}
