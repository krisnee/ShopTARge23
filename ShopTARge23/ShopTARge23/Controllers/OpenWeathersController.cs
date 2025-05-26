using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.Dto.WeatherDtos.OpenWeatherDtos;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models.OpenWeathers;

namespace ShopTARge23.Controllers
{
    public class OpenWeathersController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;

        public OpenWeathersController(IOpenWeatherServices openWeatherServices)
        {
            _openWeatherServices = openWeatherServices;
        }

        public IActionResult Index()
        {
            var vm = new OpenWeatherSearchViewModel();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> SearchCity(OpenWeatherSearchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new OpenWeatherResultDto()
                {
                    CityName = vm.CityName
                };

                var result = await _openWeatherServices.GetOpenWeatherResult(dto);

                var weatherVm = new OpenWeatherViewModel()
                {
                    CityName = result.CityName,
                    Temperature = result.Temperature,
                    Description = result.Description,
                    WeatherMain = result.WeatherMain,
                    FeelsLike = result.FeelsLike,
                    TempMin = result.TempMin,
                    TempMax = result.TempMax,
                    Humidity = result.Humidity,
                    Pressure = result.Pressure,
                    WindSpeed = result.WindSpeed,
                    WindDeg = result.WindDeg,
                    Cloudiness = result.Cloudiness,
                    Icon = result.Icon
                };

                return RedirectToAction("City", weatherVm);
            }

            return View("Index", vm);
        }

        public IActionResult City(OpenWeatherViewModel vm)
        {
            return View(vm);
        }
    }
}