using Microsoft.AspNetCore.Mvc;

namespace _100_DataTransferUsingMiddlewareInMVCCore.Controllers
{
    public class MiddlewareController : Controller
    {
        public IActionResult Index()
        {
            // Access the custom header added by the middleware
            var customHeaderValue = HttpContext.Response.Headers["X-Custom-Header"];

            // Access the data stored in HttpContext.Items["SMAK"]
            var data = HttpContext.Items["SMAK"] as string;

            // Set ViewBag with both custom header value and data
            ViewBag.CustomHeader = customHeaderValue;
            ViewBag.Data = data;

            return View();
        }

    }
}
