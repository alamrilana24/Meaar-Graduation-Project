using Meaar5.Data;
using Meaar5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meaar5.Controllers
{
    public class ManageCourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageCourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ManageCources()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        // this method used to show the list of courses assigned to a faculty member and
        // also show the dropdown to assign new courses
        public IActionResult Index(string? FacultyId)
        {
            // Load all faculty members and courses for the dropdowns
            //from the database and pass them to the
            ViewBag.FacultyMembers = _context.FacultyMembers.ToList();
            ViewBag.Courses = _context.Courses.ToList();

            // 
            if (!string.IsNullOrEmpty(FacultyId))
            {
                var doc = _context.FacultyMembers.FirstOrDefault(x => x.FacultyId == FacultyId);
                ViewBag.DoctorName = doc == null ? "" : $"{doc.FirstName} {doc.LastName}";
            }
            
            if (string.IsNullOrEmpty(FacultyId))
                return View("ManageCources", new List<FacultyCources>());

            var assigned = _context.FacultyCources
                .Include(x => x.Course)
                .Where(x => x.FacultyId == FacultyId)
                .ToList();

            return View("ManageCources", assigned);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Assign(string FacultyId, int CourseId , string Section)
        {
            if (string.IsNullOrEmpty(FacultyId))
                return RedirectToAction("Index");

            bool exists = _context.FacultyCources
                .Any(x => x.FacultyId == FacultyId && x.CourseId == CourseId && x.Section == Section);

            if (!exists)
            {
                _context.FacultyCources.Add(new FacultyCources
                {
                    FacultyId = FacultyId,
                    CourseId = CourseId,
                    Section = Section
                });

                _context.SaveChanges();
            }

            return RedirectToAction("Index", new { FacultyId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id, string FacultyId)
        {
            var assignment = _context.FacultyCources.Find(id);

            if (assignment != null)
            {
                _context.FacultyCources.Remove(assignment);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", new { FacultyId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveSelected(string FacultyId, List<int> selectedIds)
        {
            if (selectedIds == null || selectedIds.Count == 0)
                return RedirectToAction("Index", new { FacultyId });

            var rows = _context.FacultyCources
                .Where(x => selectedIds.Contains(x.Id))
                .ToList();

            _context.FacultyCources.RemoveRange(rows);
            _context.SaveChanges();

            return RedirectToAction("Index", new { FacultyId });
        }



    }
}
