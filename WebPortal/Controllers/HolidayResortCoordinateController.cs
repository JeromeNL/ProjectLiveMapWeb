using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace WebPortal.Controllers;

public class HolidayResortCoordinateController(LiveMapDbContext context) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Add(int Id, int Latitude, int Longitude)
    {
        var resortId = Id;
        var resort = await context.HolidayResorts
            .Include(r => r.HolidayResortCoordinates)
            .FirstOrDefaultAsync(r => r.Id == resortId);

        if (resort == null || resort.HolidayResortCoordinates.IsNullOrEmpty())
        {
            return RedirectToAction("Index", "Resort");
        }

        var coordinate = new HolidayResortCoordinate();
        coordinate.HolidayResortId = resortId;
        coordinate.HolidayResort = resort;
        coordinate.Latitude = Latitude;
        coordinate.Longitude = Longitude;
        coordinate.Order = resort.HolidayResortCoordinates.Count + 1;

        await context.HolidayResortCoordinates.AddAsync(coordinate);
        await context.SaveChangesAsync();

        return RedirectToAction("Details", "Resort", new { resortId });
    }
}