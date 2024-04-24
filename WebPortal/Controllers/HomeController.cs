using System.Diagnostics;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Controllers.Base;
using WebPortal.Models;

namespace WebPortal.Controllers;

public class HomeController(LiveMapDbContext context) : LivemapController
{
    public async Task<IActionResult> Index()
    {
        if (HttpContext.Session.GetInt32("resortId") == null || HttpContext.Session.GetInt32("resortId") == 0)
        {
            return RedirectToAction(nameof(SelectCurrentResort));
        }
        
        var resort = await context.HolidayResorts.FindAsync(ResortId);

        return View(resort);
    }

    public IActionResult SelectCurrentResort()
    {
        var resorts = context.HolidayResorts.ToList();
        return View(resorts);
    }

    public IActionResult SaveCurrentResort(int resortId)
    {
        HttpContext.Session.SetInt32("resortId", resortId);
        return RedirectToAction(nameof(Index));
    }
    
    public IActionResult ClearCurrentResort()
    {
        HttpContext.Session.SetInt32("resortId", 0);
        return RedirectToAction(nameof(SelectCurrentResort));
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public async Task<IActionResult> CanConnect()
    {
        try
        {
            if (await context.Database.CanConnectAsync())
            {
                return Ok("Connection to the database was successful.");
            }
            else
            {
                return Problem("Unable to connect to the database.");
            }
        }
        catch (Exception ex)
        {
            return Problem($"An error occurred while trying to connect to the database: {ex.Message}");
        }
    }
}