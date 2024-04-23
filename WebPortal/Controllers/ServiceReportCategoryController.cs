using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace WebPortal.Controllers;

public class ServiceReportCategoryController(LiveMapDbContext context) : LivemapController
{
    public async Task<IActionResult> Index()
    {
        var categories = await context.ServiceReportCategories
            .Where(f => f.HolidayResortId == ResortId)
            .ToListAsync();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(ServiceReportCategory category)
    {
        if (!ModelState.IsValid)
        {
            return View("Create", category);
        }
        await context.ServiceReportCategories.AddAsync(category);
        await context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var category = await context.ServiceReportCategories.FindAsync(id);
        return View(category);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(ServiceReportCategory category)
    {
        if (!ModelState.IsValid)
        {
            return View("Edit", category);
        }
        var existingCategory = await context.ServiceReportCategories.FindAsync(category.Id);

        if (existingCategory == null) RedirectToAction("Index");

        existingCategory.Name = category.Name;
        await context.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var reports = await context.ServiceReports.Where(r => r.ServiceReportCategoryId == id).ToListAsync();
        if (!reports.IsNullOrEmpty())
        {
            ViewBag.message = "Deze categorie kan niet verwijderd worden omdat deze aan een service melding gekoppeld is";
            return View("Index", await context.ServiceReportCategories.ToListAsync());
        }
        
        var category = await context.ServiceReportCategories.FindAsync(id);
        if (category == null) return RedirectToAction("Index");

        context.ServiceReportCategories.Remove(category);
        await context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}