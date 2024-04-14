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

        var facility = await context.Facilities.FirstAsync(e => facilityId == e.Id);

        var viewModel = new SpecialOpeningHoursViewModel
        {
            Facility = facility,
            SpecialOpeningHoursList = specialHours
        };

        return View("SpecialOpeningHours", viewModel);
    }

}