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
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnv;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository eRep, 
                              Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnv)
        {
            _logger = logger;
            _eRep = eRep;
            _hostingEnv = hostingEnv;
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

            Employee employee1 = _eRep.GetEmployee(id.Value);
            if(employee1 == null)
            {
                Response.StatusCode = 404;

                return View("EmployeeNotFound", id.Value);
            }

            HomeDetailsViewModel hDVM = new HomeDetailsViewModel()
            {
                Employee1 = employee1,
                PageTitle = "Employee Details"
            };

            return View(hDVM);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _eRep.GetEmployee(id);
            EmployeeEditViewModel empEVM = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath1
            };

            return View(empEVM);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                Employee employee = _eRep.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                if(model.Photo != null)
                {
                    if(model.ExistingPhotoPath != null)
                    {
                        String filePath = Path.Combine(_hostingEnv.WebRootPath, "images", 
                            model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath1 = ProcessUploadedFile(model);
                }
       
                _eRep.UpdateEmployee(employee);

                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath1 = uniqueFileName
                };

                _eRep.AddEmployee(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();
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

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                String uploadsFolder = Path.Combine(_hostingEnv.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);

                }
            }

            return uniqueFileName;

        }
    }
}







