using Microsoft.AspNetCore.Mvc;
using WebAppWeather.Models.Weather;

namespace WebAppWeather.Controllers.Interfaces
{
    public interface IWeathersController
    {
        Task<ActionResult<CurrentWeather>> GetCurrentWeather(int id);
        Task<ActionResult<IEnumerable<CurrentWeather>>> GetListCurrentWeather(int[] ids);
        //Task<ActionResult> GetWeatherForecast(int id, int cnt);
        //Task<ActionResult> GetMapLayer(double x, double y, MapLayerEnum mapLayer = MapLayerEnum.All);
        //Task<ActionResult> GetMapsRussia();
    }
}
