using AcademyWebsite.Data;
using AcademyWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        [Authorize]
        public IActionResult Delete(int id)
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
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Course/Join/{courseId}")]
        public IActionResult Join(int courseId)
        {
            var course = _context.Courses.Include(c => c.Childrens).FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                return NotFound();
            }

            var joinViewModel = new JoinChildViewModel
            {
                CourseId = courseId,
                CourseName = course.Name,
                CourseAge = course.Age
            };

            return View(joinViewModel);
        }

        [HttpPost]
        public IActionResult Join(JoinChildViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Find the course by ID
                var course = _context.Courses.Include(c => c.Childrens).FirstOrDefault(c => c.Id == viewModel.CourseId);
                if (course == null)
                {
                    return NotFound();
                }

                // Create a new Children object
                var child = new Children
                {
                    Name = viewModel.Name,
                    ParentName = viewModel.ParentName,
                    Email = viewModel.Email,
                    ChildAge = viewModel.ChildAge,
                    CourseId = viewModel.CourseId // Set the foreign key
                };

                // Add the child to the database
                _context.Childrens.Add(child); // Ensure you're using the correct DbSet
                _context.SaveChanges(); // Save changes to the database

                return RedirectToAction("Index");
            }

            // If model state is invalid, return the view with validation errors
            return View(viewModel);
        }

    }
}

