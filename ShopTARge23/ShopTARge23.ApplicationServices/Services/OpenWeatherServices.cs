using System.Net;
using System.Text.Json;
using ShopTARge23.Core.Dto.WeatherDtos.OpenWeatherDtos;
using ShopTARge23.Core.ServiceInterface;

namespace ShopTARge23.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeatherServices
    {
        public async Task<OpenWeatherResultDto> GetOpenWeatherResult(OpenWeatherResultDto dto)
        {
            string apiKey = "a8352065f3d8f6f4dcedd8dc497def48";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.CityName}&appid={apiKey}&units=metric";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                OpenWeatherRootDto weatherResult = JsonSerializer.Deserialize<OpenWeatherRootDto>(json);

                dto.CityName = weatherResult.Name;
                dto.Temperature = weatherResult.Main.Temp;
                dto.Description = weatherResult.Weather[0].Description;
                dto.WeatherMain = weatherResult.Weather[0].Main;
                dto.FeelsLike = weatherResult.Main.FeelsLike;
                dto.TempMin = weatherResult.Main.TempMin;
                dto.TempMax = weatherResult.Main.TempMax;
                dto.Humidity = weatherResult.Main.Humidity;
                dto.Pressure = weatherResult.Main.Pressure;
                dto.WindSpeed = weatherResult.Wind.Speed;
                dto.WindDeg = weatherResult.Wind.Deg;
                dto.Cloudiness = weatherResult.Clouds.All;
                dto.Icon = weatherResult.Weather[0].Icon;
            }

            return dto;
        }
    }
}