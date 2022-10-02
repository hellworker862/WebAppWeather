﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace WebAppWeather.Models.Weather
{
    public class Weather
    {
        private string description;

        public Weather(string name, string description, string icon)
        {
            Name = name;
            Description = description;
            Icon = icon;    
        }

        [JsonProperty(PropertyName = "main")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description
        {
            get { return description; }
            set
            {
                description = char.ToUpper(value[0]) + value.Substring(1); ;
            }
        }
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
    }
}
