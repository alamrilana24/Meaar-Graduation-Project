using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Meaar5.Data;
using System.Linq;
using Meaar5.Models;

namespace Meaar5.Controllers
{
    public class Login1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Login1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Login1/Login1?role=Faculty
        [HttpGet]
        public IActionResult Login1(string role)
        {
            role = string.IsNullOrWhiteSpace(role) ? "Faculty" : role.Trim();
            ViewBag.Role = role;
            return View();
        }

        [HttpPost]
        public IActionResult Login1(string role, string name, string password)
        {
            role = string.IsNullOrWhiteSpace(role) ? "Faculty" : role.Trim();

            name = (name ?? "").Trim();       // هذا Email
            password = (password ?? "").Trim();

            ViewBag.Role = role;
            ViewBag.EmailValue = name;

            // تحقق فاضي
            if (string.IsNullOrWhiteSpace(name))
                ModelState.AddModelError("name", "Please enter your Email");

            if (string.IsNullOrWhiteSpace(password))
                ModelState.AddModelError("password", "Please enter your Password");

            //  تحقق شكل الإيميل
            if (!string.IsNullOrWhiteSpace(name) && (!name.Contains("@") || !name.Contains(".")))
                ModelState.AddModelError("name", "Invalid Email Address");

            //  تحقق طول الباسورد (إذا مو فاضي)
            if (!string.IsNullOrWhiteSpace(password) && password.Length < 8)
                ModelState.AddModelError("password", "Password must be at least 8 characters.");

            if (!ModelState.IsValid)
                return View();

            // Normalize
            var email = name.ToLower();

            //  هنا الفرق الحقيقي: نبحث حسب role
            if (role == "Faculty")
            {
                var faculty = _context.FacultyMembers
                    .AsNoTracking()
                    .FirstOrDefault(f => f.Email.ToLower() == email);

                if (faculty == null)
                {
                    ModelState.AddModelError("name", "Email not found");
                    return View();
                }

                if (faculty.Password != password)
                {
                    ModelState.AddModelError("password", "Incorrect Password");
                    return View();
                }

                return RedirectToAction("Mycourses", "Home", new { FacultyId = faculty.FacultyId });
            }

            if (role == "DepartmentHead")
            {
                var head = _context.DepartmentHeads
                    .AsNoTracking()
                    .FirstOrDefault(d => d.Email.ToLower() == email);

                if (head == null)
                {
                    ModelState.AddModelError("name", "Email not found");
                    return View();
                }

                if (head.Password != password)
                {
                    ModelState.AddModelError("password", "Incorrect Password");
                    return View();
                }

                // غيري الوجهة حسب صفحاتك الفعلية
                return RedirectToAction("Index", "ManageCources");
            }

            if (role == "Admin")
            {
                var admin = _context.Admins
                    .AsNoTracking()
                    .FirstOrDefault(a => a.Email.ToLower() == email);

                if (admin == null)
                {
                    ModelState.AddModelError("name", "Email not found");
                    return View();
                }

                if (admin.Password != password)
                {
                    ModelState.AddModelError("password", "Incorrect Password");
                    return View();
                }

                return RedirectToAction("Addcources", "Admin");
            }

            // أي role غريب
            ModelState.AddModelError("name", "Invalid role");
            return View();
        }
    }
}