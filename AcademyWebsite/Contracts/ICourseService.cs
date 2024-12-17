using AcademyWebsite.Models;

namespace AcademyWebsite.Contracts
{
    public interface ICourseService
    {
        public List<Course> GetAllCourses();

        public Course GetCourseById(int id);

        public void AddCourse(Course course);

        public void UpdateCourse(int id, Course updatedCourse);

        public void DeleteCourse(int id);

        public void AddChildToCourse(Children child);
    }

}
