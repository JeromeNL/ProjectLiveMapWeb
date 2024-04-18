using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebPortal.Controllers;

public class ResortController(LiveMapDbContext context) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var resorts = context.HolidayResorts.ToList();
        return View(resorts);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int resortId)
    {
        var resort = await context.HolidayResorts.FindAsync(resortId);
        
        if(resort != null)
            context.HolidayResorts.Remove(resort);
        
        await context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Create(HolidayResort holidayResort)
    {
       
        context.HolidayResorts.Add(holidayResort);
        context.SaveChanges();
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
        var resort = await context.HolidayResorts.FindAsync(resortId);
        
        if(resort != null)
            return View(resort);
        
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Update(HolidayResort holidayResort)
    {
        context.Update(holidayResort);
        await context.SaveChangesAsync();
        return RedirectToAction("Details", holidayResort.Id);
    }
}

