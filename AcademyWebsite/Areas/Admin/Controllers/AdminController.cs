using AcademyWebsite.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

[Area("Admin")]
public class AdminController : Controller
{
    private readonly AcademyWebsiteContext _context;

    public AdminController(AcademyWebsiteContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> AddRole()
    {
        var users = await _context.Users
            .Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.UserName
            })
            .ToListAsync();

        var viewModel = new AddRoleViewModel
        {
            Users = users
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AddRole(AddRoleViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // Repopulate the users dropdown if validation fails
            model.Users = await _context.Users
                .Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.UserName
                })
                .ToListAsync();

            return View(model);
        }

        // Add your role creation logic here

        return RedirectToAction(nameof(Index));
    }
}