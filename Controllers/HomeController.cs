using System.Diagnostics;
using Meaar5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meaar5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // to return the view for the home page
        public IActionResult Index()
        {
            return View();
        }

        


        // to return the view for the privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //To view the page for the users 
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]

        //To receive the data after Register
        public IActionResult CreateAccount(User newUser)
        {
            if (ModelState.IsValid)
            {
                //��� �������� ������ �����ɡ ��� ����� ����� �������� ��� ������ ��������........... ������ ������� ��� ���� �����
                //??? ???????? ?????? ??????? ??? ????? ????? ???????? ??? ?????? ????????........... ?????? ??????? ??? ???? ?????
                return RedirectToAction("Index");
            }

            return View(newUser);
        }

        public IActionResult MyCourses()
        {
            return View();
        }

    }
}

    


