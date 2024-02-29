using System.Diagnostics;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPortal.Models;

namespace WebPortal.Controllers;

public class HomeController(DbContext context) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Map()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
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