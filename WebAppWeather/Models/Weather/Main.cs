﻿using System.Text.Json.Serialization;

namespace WebAppWeather.Models.Weather
{
    public class Main
    {
        public Main()
        {

        }

        [JsonPropertyName("temp")]
        public double Temperature { get; set; }
        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
        [JsonPropertyName("temp_min")]
        public double TemperatureMin { get; set; }
        [JsonPropertyName("temp_max")]
        public double TemperatureMax { get; set; }
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }
}
