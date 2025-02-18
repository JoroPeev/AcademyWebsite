using AcademyWebsite.Data;
using Microsoft.AspNetCore.Mvc;

namespace AcademyWebsite.Controllers
{
    public class HomeController(AcademyWebsiteContext context) : Controller
    {
        //Primary Constructor
        private readonly AcademyWebsiteContext _context = context;

        public IActionResult Index()
        {
            return View();
        }
        [RedirectIfNotAuthenticated]
        public IActionResult Chat()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

    }
}
