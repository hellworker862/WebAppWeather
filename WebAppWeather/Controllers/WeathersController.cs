using Microsoft.AspNetCore.Mvc;
using WebAppWeather.Controllers.Interfaces;
using WebAppWeather.Models.Places;
using WebAppWeather.Models.Weather.View.Current;
using WebAppWeather.Services;

namespace WebAppWeather.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeathersController : ControllerBase, IWeathersController
    {
        private WeathersService _weathersService;
        private SearchService _searchService;

        public WeathersController(WeathersService weathersService, SearchService searchService)
        {
            _weathersService = weathersService;
            _searchService = searchService;
        }

        [HttpGet("cities/{searchString}")]
        public async Task<ActionResult<IEnumerable<City>>> GetCitysBySeachString(string searchString)
        {
            var cities = await _searchService.SearchCity(searchString);

            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CurrentWeatherView>> GetCurrentWeather(int id)
        {
            var weather = await _weathersService.GetCurrentWeather(id);
            if (weather == null)
                return NotFound();

            return Ok(weather);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrentWeatherView>>> GetListCurrentWeather([FromQuery] int[] id)
        {
            if (id.Length == 0)
                return BadRequest();

            var list = new List<CurrentWeatherView>();

            for (int i = 0; i < id.Length; i++)
            {
                var weather = await _weathersService.GetCurrentWeather(id[i]);
                if (weather == null)
                    return NotFound();

                list.Add(weather);
            }

            return Ok(list);
        }

        [HttpGet("forecast/{id}")]
        public async Task<ActionResult> GetWeatherForecast(int id)
        {
            var forecast = await _weathersService.GetWeatherForecast(id);
            if (forecast == null)
                return NotFound();

            return Ok(forecast);
        }
    }

}