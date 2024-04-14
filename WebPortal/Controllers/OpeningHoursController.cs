using System.Diagnostics;
using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPortal.Models;

namespace WebPortal.Controllers;

public class OpeningHoursController(LiveMapDbContext context) : Controller
{
   
    
    
    [HttpPost]
    public async Task<IActionResult> SaveOpeningHours(OpeningHoursInputModel model)
    {
        if (ModelState.IsValid)
        {
            foreach (var dayHours in model.DayHours)
            {
                var existingHours = context.DefaultOpeningHours
                    .FirstOrDefault(e => e.FacilityId == model.FacilityId && e.WeekDay == dayHours.Day);

                if (existingHours != null)
                {
                    existingHours.OpenTime = new TimeOnly(dayHours.OpenTime.Hours, dayHours.OpenTime.Minutes);
                    existingHours.CloseTime = new TimeOnly(dayHours.CloseTime.Hours, dayHours.CloseTime.Minutes);
                }
                else
                {
                    var newHours = new DefaultOpeningHours(dayHours.Day)
                    {
                        OpenTime = new TimeOnly(dayHours.OpenTime.Hours, dayHours.OpenTime.Minutes),
                        CloseTime = new TimeOnly(dayHours.CloseTime.Hours, dayHours.CloseTime.Minutes),
                        FacilityId = model.FacilityId
                    };
                    context.DefaultOpeningHours.Add(newHours);
                }
            }
            await context.SaveChangesAsync();
            return RedirectToAction("Show", "Facility", new { id = model.FacilityId });
        }
        // Handle the case when the model is not valid
        return RedirectToAction("Show", "Facility", new { id = model.FacilityId });
    }

    [HttpGet]
    public async Task<IActionResult> SpecialOpeningHours(int facilityId)
    {
        var specialHours = context.SpecialOpeningHours
            .Where(oh => oh.FacilityId == facilityId)
            .ToList();

        var FacilityObject = await context.Facilities.FirstOrDefaultAsync(e => e.Id == facilityId);
        if (FacilityObject == null)
        {
            return NotFound("Faciliteit niet gevonden.");
        }
        
        var viewModel = new SpecialOpeningHoursViewModel
        {
            Facility = FacilityObject,
            SpecialOpeningHoursList = specialHours
        };

        return View("SpecialOpeningHours", viewModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> SaveSpecialOpeningHours(int facilityId, SpecialOpeningHours newOpeningHour)
    {
        if (newOpeningHour != null)
        {
            newOpeningHour.FacilityId = facilityId;
            context.SpecialOpeningHours.Add(newOpeningHour);
            await context.SaveChangesAsync();
        }

        return RedirectToAction("SpecialOpeningHours", facilityId);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteSpecialOpeningHour(int facilityId, DateOnly date)
    {
        var specialHour = await context.SpecialOpeningHours.FindAsync(date, facilityId);
        if (specialHour != null)
        {
            context.SpecialOpeningHours.Remove(specialHour);
            await context.SaveChangesAsync();
            return RedirectToAction("SpecialOpeningHours", new { facilityId = specialHour.FacilityId });
        }
        return NotFound();
    }


}