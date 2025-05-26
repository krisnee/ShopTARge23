﻿namespace ShopTARge23.Core.Dto.WeatherDtos.OpenWeatherDtos
{
    public class OpenWeatherResultDto
    {
        public string CityName { get; set; }
        public double Temperature { get; set; }
        public string Description { get; set; }
        public string WeatherMain { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public double WindSpeed { get; set; }
        public int WindDeg { get; set; }
        public int Cloudiness { get; set; }
        public string Icon { get; set; }
    }
}