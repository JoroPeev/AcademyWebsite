using AcademyWebsite.Contracts;
using AcademyWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcademyWebsite.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var courses = _courseService.GetAllCourses();
            return View(courses);
        }

        public IActionResult SuccessfullyAddedChild()
        {
            return View();
        }

        [HttpGet]
        [RedirectIfNotAuthenticated]
        public IActionResult Add()
        {
            var subjects = new List<string> { "Math", "Science", "Language", "Art" };
            ViewBag.Subjects = new SelectList(subjects);
            return View();
        }

        [HttpPost]
        [RedirectIfNotAuthenticated]
        public IActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseService.AddCourse(course);
                return RedirectToAction("Index");
            }

            var subjects = new List<string> { "Math", "Science", "Language", "Art" };
            ViewBag.Subjects = new SelectList(subjects);
            return View(course);
        }

        [HttpGet]
        [RedirectIfNotAuthenticated]
        public IActionResult Edit(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }

            var subjects = new List<string> { "Math", "Science", "Language", "Art" };
            ViewBag.Subjects = new SelectList(subjects);

            return View(course);
        }

        [HttpPost]
        [RedirectIfNotAuthenticated]
        public IActionResult Edit(int id, Course updatedCourse)
        {
            if (id != updatedCourse.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _courseService.UpdateCourse(id, updatedCourse);
                return RedirectToAction("Index");
            }

            return View(updatedCourse);
        }

        [HttpGet]
        [RedirectIfNotAuthenticated]
        public IActionResult Delete(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        [RedirectIfNotAuthenticated]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Course/Join/{courseId}")]
        public IActionResult Join(int courseId)
        {
            var course = _courseService.GetCourseById(courseId);
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
                var course = _courseService.GetCourseById(viewModel.CourseId);
                if (course == null)
                {
                    return NotFound();
                }

                var child = new Children
                {
                    Name = viewModel.Name,
                    ParentName = viewModel.ParentName,
                    Email = viewModel.Email,
                    ChildAge = viewModel.ChildAge,
                    CourseId = course.Id
                };

                _courseService.AddChildToCourse(child);
                return RedirectToAction("SuccessfullyAddedChild");
            }

            return View(viewModel);
        }
    }
}
