using System.Diagnostics;
using CoreApplication1.Models;
using CoreApplication1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _eRep;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository eRep)
        {
            _logger = logger;
            _eRep = eRep;
        }

        public ActionResult Index()
        {
            var tmp = _eRep.GetAllEmployees();
            return View(tmp);
        }

        public String About()
        {
            return "About Message";
        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel hDVM = new HomeDetailsViewModel()
            {
                Employee1 = _eRep.GetEmployee(id ?? 1),
                PageTitle = "Employee Details"
            };

            return View(hDVM);
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




