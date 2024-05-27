using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebPortal.Controllers;

[Authorize(Roles = "ResortAdmin")]
public class ResortController(LiveMapDbContext context, UserManager<ApplicationUser> userManager) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await userManager.GetUserAsync(User);
        ViewBag.UserResortId = user.HolidayResortId;
        var resorts = await context.HolidayResorts.ToListAsync();
        return View(resorts);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int resortId)
    {
        var resort = await context.HolidayResorts.FindAsync(resortId);

        if (resort != null)
            context.HolidayResorts.Remove(resort);

        await context.SaveChangesAsync();
        TempData["InfoMessage"] = "Park " + resort.Name + " is verwijderd.";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Create(HolidayResort holidayResort)
    {
        if (!ModelState.IsValid)
        {
            return View(holidayResort);
        }

        await context.HolidayResorts.AddAsync(holidayResort);
        await context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Park " + holidayResort.Name + " is aangemaakt.";
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Details(int resortId)
    {
        var resort = await context.HolidayResorts
            .FirstOrDefaultAsync(r => r.Id == resortId);

        if (resort == null)
            return RedirectToAction("Index");

        return View(resort);
    }

    [HttpPost]
    public async Task<IActionResult> Update(HolidayResort holidayResort)
    {
        if (!ModelState.IsValid)
        {
            return View("Details", holidayResort);
        }

        context.Update(holidayResort);
        await context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Park " + holidayResort.Name + " is bijgewerkt.";
        return RedirectToAction("Details", holidayResort.Id);
    }
}