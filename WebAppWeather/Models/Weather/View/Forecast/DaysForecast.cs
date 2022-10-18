namespace WebAppWeather.Models.Weather.View.Forecast
{
    public class DayForecast
    {
        public DayForecast(string weekDay, 
                           string weatherName, 
                           string data, 
                           string icon, 
                           int maxTemperature, 
                           int minTemperature,
                           int temperature,
                           int feelsLike,
                           int humidity,
                           int pressure,
                           Wind wind)
        {
            WeekDay = weekDay;
            WeatherName = weatherName;
            Data = data;
            Icon = icon;
            MaxTemperature = maxTemperature;
            MinTemperature = minTemperature;
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
            Wind = wind;
            FeelsLike = feelsLike;
        }

        private string _weekDay;
        private string _weatherName;

        public string WeekDay
        {
            get { return _weekDay; }
            set 
            {
                value = value.First().ToString().ToUpper() + value.Substring(1);
                _weekDay = value;
            }
        }
        public string WeatherName
        {
            get { return _weatherName; }
            set 
            {
                value = value.First().ToString().ToUpper() + value.Substring(1);
                _weatherName = value;
            }
        }
        public string Data { get; set; }
        public string Icon { get; set; }
        public int MaxTemperature { get; set; }
        public int MinTemperature { get; set; }
        public int Temperature { get; set; }
        public int FeelsLike { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public Wind Wind { get; set; }

    }
}
