using Microsoft.AspNetCore.Mvc;
using WebAppWeather.Controllers.Interfaces;
using WebAppWeather.Models.Weather.Data.Current;
using WebAppWeather.Models.Weather.View.Current;
using WebAppWeather.Services;

namespace WebAppWeather.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeathersController : ControllerBase, IWeathersController
    {
        private WeathersService _weathersService;

        public WeathersController(WeathersService weathersService)
        {
            _weathersService = weathersService;
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
    }

}