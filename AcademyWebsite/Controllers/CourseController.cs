using AcademyWebsite.Data;
using AcademyWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademyWebsite.Controllers
{
    public class CourseController : Controller
    {
        private readonly AcademyWebsiteContext _context;

        public CourseController(AcademyWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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
        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, Course updatedCourse)
        {
            if (id != updatedCourse.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var course = _context.Courses.FirstOrDefault(c => c.Id == id);
                if (course == null)
                {
                    return NotFound();
                }

                // Update course properties
                course.Name = updatedCourse.Name;
                course.Price = updatedCourse.Price;
                course.Age = updatedCourse.Age;
                course.StartDate = updatedCourse.StartDate;
                course.EndDate = updatedCourse.EndDate;
                course.Details = updatedCourse.Details;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(updatedCourse);
        }
    }
}

