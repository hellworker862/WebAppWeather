using Newtonsoft.Json;
using WebAppWeather.Enums;

namespace WebAppWeather.Models.Weather.View
{
    public class Wind
    {
        public Wind(int speed, int degrees, WindTypeEnum gust, DirectionsEnum direction)
        {
            Speed = speed;
            Degrees = degrees;
            GustDescription = gust switch
            {
                WindTypeEnum.Calm => "штиль",
                WindTypeEnum.Quiet => "тихий ветер",
                WindTypeEnum.Light => "легкий ветер",
                WindTypeEnum.Week => "слабый ветер",
                WindTypeEnum.Moderate => "умереный ветер",
                WindTypeEnum.Fresh => "свежий ветер",
                WindTypeEnum.High => "сильный ветер",
                WindTypeEnum.Strong => "крепкий ветер",
                WindTypeEnum.VeryStrong => "очень крепкий ветер",
                WindTypeEnum.Storm => "шторм",
                WindTypeEnum.HeavyStorm => "сильный шторм",
                WindTypeEnum.ViolentStorm => "жестокий шторм",
                WindTypeEnum.Hurricane => "ураган",
                _ => "неизвестно"
            };
            Direction = direction switch
            {
                DirectionsEnum.Northern => "север",
                DirectionsEnum.Northeastern => "северо-восток",
                DirectionsEnum.Northwestern => "северо-запад",
                DirectionsEnum.Southern => "юг",
                DirectionsEnum.Southwestern => "юго-запад",
                DirectionsEnum.Southeastern => "юго-восток",
                DirectionsEnum.Eastern => "восток",
                DirectionsEnum.West => "запад",
                _ => "неизвестно"
            };
        }

        public int Speed { get; set; }
        public int Degrees { get; set; }
        public string GustDescription { get; set; }
        public string Direction { get; set; }

    }
}
