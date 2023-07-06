using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ITestTableServices _test2;

        public WeatherForecastController(ITestTableServices test2)
        {
            _test2 = test2;
        }

        [HttpGet]
        public IActionResult test1()
        {
            _test2.testa();
            return new JsonResult(new { code = 200 });
        }
    }
}