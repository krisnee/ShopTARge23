using System.Text.Json.Serialization;

namespace ShopTARge23.Core.Dto.WeatherDtos.OpenWeatherDtos
{
    public class OpenWeatherRootDto
    {
        [JsonPropertyName("coord")]
        public CoordDto Coord { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherDto> Weather { get; set; }

        [JsonPropertyName("main")]
        public MainDto Main { get; set; }

        [JsonPropertyName("wind")]
        public WindDto Wind { get; set; }

        [JsonPropertyName("clouds")]
        public CloudsDto Clouds { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cod")]
        public int Cod { get; set; }
    }

    public class CoordDto
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }

    public class WeatherDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }

    public class MainDto
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class WindDto
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public int Deg { get; set; }
    }

    public class CloudsDto
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }
}