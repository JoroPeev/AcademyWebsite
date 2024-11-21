using AcademyWebsite.Data;
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
    }
}
