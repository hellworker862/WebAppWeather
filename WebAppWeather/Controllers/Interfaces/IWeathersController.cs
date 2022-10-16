using Microsoft.AspNetCore.Mvc;
using WebAppWeather.Models.Places;
using WebAppWeather.Models.Weather.Data.Current;
using WebAppWeather.Models.Weather.View.Current;

namespace WebAppWeather.Controllers.Interfaces
{
    public interface IWeathersController
    {
        Task<ActionResult<CurrentWeatherView>> GetCurrentWeather(int id);
        Task<ActionResult<IEnumerable<CurrentWeatherView>>> GetListCurrentWeather(int[] ids);

        Task<ActionResult<IEnumerable<City>>> GetCitysBySeachString(string searchString);
        //Task<ActionResult> GetWeatherForecast(int id, int cnt);
        //Task<ActionResult> GetMapLayer(double x, double y, MapLayerEnum mapLayer = MapLayerEnum.All);
        //Task<ActionResult> GetMapsRussia();
    }
}
