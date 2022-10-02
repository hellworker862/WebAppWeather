using Microsoft.AspNetCore.Mvc;
using WebAppWeather.Controllers.Interfaces;
using WebAppWeather.Enums;
using WebAppWeather.Models.Weather;

namespace WebAppWeather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeathersController : ControllerBase, IWeathersController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrentWeather>>> GetCurrentWeather(params int[] id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult> GetMapLayer(double x, double y, MapLayerEnum mapLayer = MapLayerEnum.All)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult> GetMapsRussia()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult> GetWeatherForecast(int id, int cnt)
        {
            throw new NotImplementedException();
        }
    }
}
