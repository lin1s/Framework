using Core.Base.Interface;
using Entity.TestDbA;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IBaseRepository<TestTable> _test;
        private readonly ITestTableServices _test2;

        public WeatherForecastController(IBaseRepository<TestTable> test, ITestTableServices test2)
        {
            _test = test;
            _test2 = test2;
        }

        [HttpGet]
        public IActionResult test1()
        {
            var a = _test.Select(x => true);
            _test2.testa();
            return new JsonResult(new { code = 200 });
        }
    }
}