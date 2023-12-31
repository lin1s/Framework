using Dto;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace Api.Controllers
{
    public class WeatherForecastController : BaseController
    {
        private readonly ITestTableServices _test2;

        public WeatherForecastController(ITestTableServices test2)
        {
            _test2 = test2;
        }

        [HttpGet]
        public IActionResult test1(WeatherForecastDto dto)
        {
            _test2.testa();
            return new JsonResult(new { code = 200 });
        }
    }
}