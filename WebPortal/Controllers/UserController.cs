using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPortal.Controllers.Base;
using WebPortal.Models;

namespace WebPortal.Controllers;

[Authorize(Roles = $"{nameof(Role.SuperAdmin)},{nameof(Role.ResortAdmin)}")]
public class UserController(LiveMapDbContext context, UserManager<ApplicationUser> userManager) : LivemapController
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await getUsersWithRole());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(RegisterViewModel viewModel)
    {
        var user = new ApplicationUser();
        user.UserName = viewModel.UserName;
        user.NormalizedUserName = viewModel.UserName.ToUpper();
        user.HolidayResortId = ResortId;
        user.HolidayResort = await context.HolidayResorts.FindAsync(ResortId);

        var result = await userManager.CreateAsync(user, viewModel.Password);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("Password", "Wachtwoord moet meer dan 10 tekens bevatten");

            return View("Create");
        }

        var currentUser = await userManager.GetUserAsync(User);
        var currentRole = await userManager.GetRolesAsync(currentUser);

        if (currentRole.FirstOrDefault() == nameof(Role.SuperAdmin))
        {
            await userManager.AddToRoleAsync(user, nameof(Role.ResortAdmin));
        }
        else
        {
            await userManager.AddToRoleAsync(user, nameof(Role.ResortEmployee));
        }

        return View("Index", await getUsersWithRole());
    }

    private async Task<Dictionary<ApplicationUser, string?>> getUsersWithRole()
    {
        var userRoles = new Dictionary<ApplicationUser, string?>();
        var users = await userManager.Users
            .Where(u => u.HolidayResortId == ResortId)
            .ToListAsync();

        foreach (var user in users)
        {
            var role = await userManager.GetRolesAsync(user);
            userRoles.Add(user, role.FirstOrDefault());
        }

        return userRoles;
    }
}