using AcademyWebsite.Data;
using AcademyWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebsite.Services
{
    public class CourseService
    {
        private readonly AcademyWebsiteContext _context;

        public CourseService(AcademyWebsiteContext context)
        {
            _context = context;
        }

        public List<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.Include(c => c.Childrens).FirstOrDefault(c => c.Id == id);
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(int id, Course updatedCourse)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course != null)
            {
                course.Name = updatedCourse.Name;
                course.Price = updatedCourse.Price;
                course.Age = updatedCourse.Age;
                course.StartDate = updatedCourse.StartDate;
                course.EndDate = updatedCourse.EndDate;
                course.Details = updatedCourse.Details;
                course.ImageUrl = updatedCourse.ImageUrl;
                course.Subject = updatedCourse.Subject;

                _context.SaveChanges();
            }
        }

        public void DeleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public void AddChildToCourse(Children child)
        {
            _context.Childrens.Add(child);
            _context.SaveChanges();
        }
    }
}