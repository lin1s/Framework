using Core.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            //请求参数
            Dictionary<string, object?> parameters = actionContext.ActionArguments.ToDictionary(x => x.Key, x => x.Value);
            string auth = actionContext.HttpContext.Request.Headers.Authorization.ToString();

            if (string.IsNullOrEmpty(auth))
            {
                actionContext.Result = Json(new { code = 401, MSG = "Token错误" });
            }

            string result = AuthHelper.ValidateJwtToken(auth, "1");
            if (result.Contains("expired"))
            {
                actionContext.Result = Json(new { code = 401, MSG = "Token已过期" });
            }
            else if (result.Contains("invalid"))
            {
                actionContext.Result = Json(new { code = 401, MSG = "Token验证未通过" });
            }
            else if (result.Contains("error"))
            {
                actionContext.Result = Json(new { code = 401, MSG = "Token错误" });
            }

        }
    }
}