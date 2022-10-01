using Microsoft.AspNetCore.Mvc;
using WebAppWeather.Controllers.Interfaces;
using WebAppWeather.Enums;

namespace WebAppWeather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeathersController : ControllerBase, IWeathersController
    {
    }
}
