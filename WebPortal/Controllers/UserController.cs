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
        return View(await GetUsersWithRole());
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var viewmodel = new RegisterViewModel();
        viewmodel.Resorts = await context.HolidayResorts.ToListAsync();
        return View(viewmodel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(RegisterViewModel viewModel, int? resortId)
    {
        var user = new ApplicationUser();
        user.UserName = viewModel.UserName;
        user.NormalizedUserName = viewModel.UserName.ToUpper();

        user.HolidayResortId = resortId ?? ResortId;
        user.HolidayResort = await context.HolidayResorts.FindAsync(resortId ?? ResortId);

        var result = await userManager.CreateAsync(user, viewModel.Password);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("Password", "Wachtwoord moet meer dan 10 tekens bevatten");

            var model = new RegisterViewModel();
            model.Resorts = await context.HolidayResorts.ToListAsync();

            return View("Create", model);
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

        return View("Index", await GetUsersWithRole());
    }

    private async Task<Dictionary<ApplicationUser, string?>> GetUsersWithRole()
    {
        var userRoles = new Dictionary<ApplicationUser, string?>();
        var u = await userManager.GetUserAsync(User);
        var roles = await userManager.GetRolesAsync(u);
        List<ApplicationUser> users = new List<ApplicationUser>();
        
        if (roles.FirstOrDefault() == nameof(Role.SuperAdmin))
        {
            users = await userManager.Users
                .ToListAsync();
        }
        else
        {
            var usersWithResortId = await userManager.Users
                .Where(user => user.HolidayResortId == ResortId)
                .ToListAsync();
            

            foreach (var user in usersWithResortId)
            {
                roles = await userManager.GetRolesAsync(user);
                if (!roles.Contains(nameof(Role.SuperAdmin)))
                {
                    users.Add(user);
                }
            }
        }

        foreach (var user in users)
        {
            var role = await userManager.GetRolesAsync(user);
            userRoles.Add(user, role.FirstOrDefault());
        }

        return userRoles;
    }
}