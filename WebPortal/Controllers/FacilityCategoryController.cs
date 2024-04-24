using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace WebPortal.Controllers;

public class FacilityCategoryController(LiveMapDbContext context) : LivemapController
{
    public async Task<IActionResult> Index()
    {
        var facilityCategories = await context.FacilityCategories
            .Where(category => category.HolidayResortId == ResortId)
            .ToListAsync();
        return View(facilityCategories);
    }

    public IActionResult Create()
    {
        ViewBag.ResortId = ResortId;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(FacilityCategory facilityCategory)
    {
        if (!ModelState.IsValid) return View(facilityCategory);

        await context.FacilityCategories.AddAsync(facilityCategory);
        await context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Categorie " + facilityCategory.Name + " is aangemaakt.";
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var facilityCategory = await context.FacilityCategories.FindAsync(id);
        ViewBag.ResortId = ResortId;
        if (facilityCategory == null) return NotFound();
        return View(facilityCategory);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(FacilityCategory facilityCategory)
    {
        if (!ModelState.IsValid) return View(facilityCategory);
        context.FacilityCategories.Update(facilityCategory);
        await context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Categorie " + facilityCategory.Name + " is bijgewerkt.";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var facilityCategory = await context.FacilityCategories.FindAsync(id);
        if (facilityCategory == null) return NotFound();

        var facilitiesWithThisCategory =
            await context.Facilities.Where(f => f.CategoryId == facilityCategory.Id).ToListAsync();
        if (!facilitiesWithThisCategory.IsNullOrEmpty())
        {
            ViewBag.message =
                "De categorie kan niet verwijderd worden omdat er nog faciliteiten aan gekoppeld zijn.";
            return View(nameof(Index), await context.FacilityCategories.ToListAsync());
        }

        context.FacilityCategories.Remove(facilityCategory);
        await context.SaveChangesAsync();
        TempData["InfoMessage"] = "Categorie " + facilityCategory.Name + " is verwijderd.";
        return RedirectToAction("Index");
    }
}