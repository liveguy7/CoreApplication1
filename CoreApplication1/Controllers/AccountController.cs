
using Microsoft.AspNetCore.Mvc;

namespace CoreApplication1.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


    }
}





