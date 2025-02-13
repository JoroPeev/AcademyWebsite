using AcademyWebsite.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult> AssignRole()
    {
        var users = _userManager.Users
            .Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.UserName
            }).ToList();

        var model = new AssignRoleViewModel
        {
            Users = users
        };

        return View(model);
    }


    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult> AssignRole(AssignRoleViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, "Manager");

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }

                ModelState.AddModelError("", "Failed to add role");
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }
        }

        model.Users = _userManager.Users
            .Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.UserName
            }).ToList();

        return View(model);
    }

}
