using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CoreApplication1.Controllers
{
    public class ErrorController : Controller
    {

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch(statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested is not found";
                    ViewBag.Path = statusCodeResult.OriginalPath;
                    ViewBag.QS = statusCodeResult.OriginalQueryString;
                    break;
            }

            return View("NotFound");

        }

        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;

            return View("Error");

        }
    }
}







