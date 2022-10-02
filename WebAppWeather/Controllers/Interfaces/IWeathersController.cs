using Microsoft.AspNetCore.Mvc;
using WebAppWeather.Enums;
using WebAppWeather.Models.Weather;

namespace WebAppWeather.Controllers.Interfaces
{
    public interface IWeathersController
    {
        Task<ActionResult<IEnumerable<CurrentWeather>>> GetCurrentWeather(params int[] id);
        Task<ActionResult> GetWeatherForecast(int id, int cnt);
        Task<ActionResult> GetMapLayer(double x, double y, MapLayerEnum mapLayer = MapLayerEnum.All);
        Task<ActionResult> GetMapsRussia();
    }
}
