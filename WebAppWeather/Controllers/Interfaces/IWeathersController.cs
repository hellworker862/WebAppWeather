using Microsoft.AspNetCore.Mvc;
using WebAppWeather.Enums;

namespace WebAppWeather.Controllers.Interfaces
{
    public interface IWeathersController
    {
        Task<IActionResult> GetCurrentWeather(params int[] id);
        Task<IActionResult> GetWeatherForecast(int id, int cnt);
        Task<IActionResult> GetMapLayer(double x, double y, MapLayerEnum mapLayer = MapLayerEnum.All);
        Task<IActionResult> GetMapsRussia();
    }
}
