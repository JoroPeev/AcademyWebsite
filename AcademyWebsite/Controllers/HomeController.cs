using AcademyWebsite.Data;
using AcademyWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AcademyWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AcademyWebsiteContext _context;


        public HomeController(ILogger<HomeController> logger, AcademyWebsiteContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegistrationData()
        {
            return View();
        }


        public IActionResult RegisteredList()
        {
            var allRegistrations = _context.RegistrationData.ToList();

            return View(allRegistrations);
        }

        public IActionResult RegistrationDetails(RegistrationData model)
        {
            var registered = new RegistrationData
            {
                Id = model.Id,
                ChildAge = model.ChildAge,
                ChildName = model.ChildName,
                EmailAddress = model.EmailAddress,
                ParentName = model.ParentName,
                PhoneNumber = model.PhoneNumber,
            };
            _context.Add(registered);
            _context.SaveChanges();

            return RedirectToAction("RegisteredList");
        }

        public IActionResult EditRegistrationData(int? id)
        {
            var datainDb = _context.RegistrationData.SingleOrDefault(ex => ex.Id == id);


            return View(datainDb);
        }
        [HttpPost]
        public IActionResult EditRegistrationData(RegistrationData registration)
        {
            if (!ModelState.IsValid)
            {
                return View(registration);
            }

            var model = _context.RegistrationData.SingleOrDefault(ex => ex.Id == registration.Id);
            if (model == null)
            {
                return NotFound();
            }

            model.PhoneNumber = registration.PhoneNumber;
            model.ParentName = registration.ParentName;
            model.EmailAddress = registration.EmailAddress;
            model.ChildName = registration.ChildName;
            model.EmailAddress = registration.EmailAddress;
            model.ChildAge = registration.ChildAge;

            _context.Update(model);
            _context.SaveChanges();

            return RedirectToAction("RegisteredList");
        }

        public IActionResult DeleteRegistrationData(int id)
        {
            var datainDb = _context.RegistrationData.SingleOrDefault(ex => ex.Id == id);
            _context.RegistrationData.Remove(datainDb);
            _context.SaveChanges();
            return RedirectToAction("RegisteredList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
