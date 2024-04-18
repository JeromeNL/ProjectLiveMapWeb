using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebPortal.Controllers;

public class ResortController(LiveMapDbContext context) : Controller
{
    public IActionResult Index()
    {
        var resorts = context.HolidayResorts.ToList();
        return View(resorts);
    }

    public async Task<IActionResult> Delete(int resortId)
    {
        var resort = await context.HolidayResorts.FindAsync(resortId);
        
        if(resort != null)
            context.HolidayResorts.Remove(resort);
        
        await context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public IActionResult Save(HolidayResort holidayResort)
    {
        context.HolidayResorts.Add(holidayResort);
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int resortId)
    {
        var resort = await context.HolidayResorts.FindAsync(resortId);
        
        if(resort != null)
            return View(resort);
        
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(HolidayResort holidayResort)
    {
        context.Update(holidayResort);
        await context.SaveChangesAsync();
        return RedirectToAction("Details", holidayResort.Id);
    }
}

