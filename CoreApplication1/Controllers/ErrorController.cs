using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace CoreApplication1.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;

        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch(statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested is not found";
                    _logger.LogWarning($"404 Error Occured. Path = {statusCodeResult.OriginalPath}");
                    _logger.LogWarning($"{statusCodeResult.OriginalQueryString}");
                    break;
            }

            return View("NotFound");

        }

        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _logger.LogError($"The path {exceptionDetails.Path} threw an exception");
            _logger.LogError($"{exceptionDetails.Error}");

            return View("Error");

        }
    }
}







