using AcademyWebsite.Data;
using AcademyWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademyWebsite.Controllers
{
    public class CourseController(AcademyWebsiteContext context) : Controller
    {
        //Primary Constructor
        private readonly AcademyWebsiteContext _context = context;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

    }
}

