using Meaar5.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Meaar5.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Addcources()
        {
            var model = _context.Courses.ToList();
            return View(model);
        }
    }
}