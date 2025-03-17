using AcademyWebsite.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademyWebsite.Controllers
{
    public class HomeController(AcademyWebsiteContext context) : Controller
    {
        private readonly AcademyWebsiteContext _context = context;

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
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
