using Microsoft.AspNetCore.Mvc;

namespace Meaar.Controllers
{
    public class MeaarController : Controller
    {
        public IActionResult Login()
        {
            return View("~/Views/Login/Index.cshtml");
        }
    }
}
