namespace WebAppWeather.Models.Weather.View
{
    public class Weather
    {
        public Weather(string weatherName, Main main, Wind wind, int clouds, string icon)
        {
            WeatherName = weatherName;
            Main = main;
            Wind = wind;
            Clouds = clouds;
            Icon = icon;
        }

        private string _weatherName;

        public string WeatherName
        {
            get { return _weatherName; }
            set
            {
                value = value.First().ToString().ToUpper() + value.Substring(1);
                _weatherName = value;
            }
        }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public int Clouds { get; set; }
        public string Icon { get; set; }
    }
}
