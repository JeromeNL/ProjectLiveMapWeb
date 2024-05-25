using System.Diagnostics;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Controllers.Base;
using WebPortal.Models;
using WebPortal.Services;

namespace WebPortal.Controllers;

public class HomeController(LiveMapDbContext context, IResortService resortService) : LivemapController
{
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Facility", null);
    }

    public async Task<IActionResult> SaveCurrentResort(int resortId)
    {
        await resortService.SetCurrentResortId(resortId);
        return Redirect(Request.Headers["Referer"].ToString());
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