using System.Diagnostics;
using CoreApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEmployeeRepository _eRep;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository eRep)
        {
            _logger = logger;
            _eRep = eRep;
        }

        public JsonResult Index()
        {
            return Json(new
            {
                _eRep.GetEmployee(1).Name,
                number = 1
            });
        }

        public String About()
        {
            return "About Message";
        }
   
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

