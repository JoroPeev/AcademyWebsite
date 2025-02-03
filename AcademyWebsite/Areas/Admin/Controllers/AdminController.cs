using AcademyWebsite.Areas.Admin.Models;
using AcademyWebsite.Data;
using AcademyWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

[Area("Admin")]
public class AdminController : Controller
{
    private readonly AcademyWebsiteContext _context;

    public AdminController(AcademyWebsiteContext context)
    {
        _context = context;
    }

    // GET: Role/Add
    public ActionResult AddRole()
    {
        var model = new AddRoleViewModel
        {
            Users = GetUsers() // Method to fetch users from the database
        };
        return View(model);
    }

    // POST: Role/Add
    [HttpPost]
    public ActionResult AddRole(AddRoleViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Save the role and selected user to the database
            SaveRole(model.RoleName, model.SelectedUserId);
            return RedirectToAction("Index"); // Redirect to a list or confirmation page
        }
        model.Users = GetUsers(); // Re-populate the user list in case of validation errors
        return View(model);
    }

    private List<SelectListItem> GetUsers()
    {
        // Fetch users from the database and convert to SelectListItem
        var users = _context.Users.Select(u => new SelectListItem
        {
            Value = u.Id,
            Text = u.UserName
        }).ToList();
        return users;
    }

    private void SaveRole(string roleName, string userId)
    {
        // Save the role and user association to the database
        var role = new Role { Name = roleName, UserId = userId };
        _context.Roles.Add(role);
        _context.SaveChanges();
    }
}