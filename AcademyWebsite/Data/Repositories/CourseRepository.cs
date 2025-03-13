using AcademyWebsite.Data;
using AcademyWebsite.Models;

public class CourseRepository : ICourseRepository
{
    private readonly AcademyWebsiteContext _context;

    public CourseRepository(AcademyWebsiteContext context)
    {
        _context = context;
    }

    public IEnumerable<Course> GetAllCourses()
    {
        return _context.Courses.ToList();
    }

    public Course GetCourseById(int id)
    {
        return _context.Courses.Find(id);
    }

    public void AddCourse(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
    }

    public void UpdateCourse(Course course)
    {
        _context.Courses.Update(course);
        _context.SaveChanges();
    }

    public void DeleteCourse(int id)
    {
        var course = _context.Courses.Find(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
    }
}
