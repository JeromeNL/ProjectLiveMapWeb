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

    public async Task<IActionResult> Delete(int facilityId)
    {
        var resort = await context.HolidayResorts.FindAsync(facilityId);
        
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
}

