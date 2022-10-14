using Newtonsoft.Json;
using WebAppWeather.Enums;

namespace WebAppWeather.Models.Weather.Data
{
    public class Wind
    {
        public Wind(double speed, int degrees, double gust)
        {
            Speed = speed;
            Degrees = degrees;
            Gust = gust;

            WindType = gust switch
            {
                var n when (n <= 1) => WindTypeEnum.Calm,
                var n when (n <= 5) => WindTypeEnum.Quiet,
                var n when (n <= 11) => WindTypeEnum.Light,
                var n when (n <= 18) => WindTypeEnum.Week,
                var n when (n <= 30) => WindTypeEnum.Moderate,
                var n when (n <= 39) => WindTypeEnum.Fresh,
                var n when (n <= 50) => WindTypeEnum.High,
                var n when (n <= 61) => WindTypeEnum.Strong,
                var n when (n <= 74) => WindTypeEnum.VeryStrong,
                var n when (n <= 87) => WindTypeEnum.Storm,
                var n when (n <= 102) => WindTypeEnum.HeavyStorm,
                var n when (n < 120) => WindTypeEnum.ViolentStorm,
                var n when (n >= 120) => WindTypeEnum.Hurricane,
                _ => WindTypeEnum.None
            };

            Direction = degrees switch
            {
                var n when (n <= 45) => DirectionsEnum.Northeastern,
                var n when (n <= 90) => DirectionsEnum.Eastern,
                var n when (n <= 135) => DirectionsEnum.Southeastern,
                var n when (n <= 180) => DirectionsEnum.Southern,
                var n when (n <= 225) => DirectionsEnum.Southwestern,
                var n when (n <= 270) => DirectionsEnum.West,
                var n when (n <= 315) => DirectionsEnum.Northwestern,
                var n when (n <= 360) => DirectionsEnum.Northern,
                _ => DirectionsEnum.None
            };
        }

        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }
        [JsonProperty(PropertyName = "deg")]
        public int Degrees { get; set; }
        [JsonProperty(PropertyName = "gust")]
        public double Gust { get; set; }
        [JsonIgnore]
        public WindTypeEnum WindType { get; set; }
        [JsonIgnore]
        public DirectionsEnum Direction { get; set; }
    }
}
