using System.Globalization;
using DataAccess;
using DataAccess.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("openinghours")]
public class OpeningHoursController : ControllerBase
{
    private readonly LiveMapDbContext _context;

    public OpeningHoursController(LiveMapDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOpeningHoursForDate(int facilityId, DateTime date)
    {
        DateTime firstDayOfWeek = ISOWeek.ToDateTime(date.Year, ISOWeek.GetWeekOfYear(date), DayOfWeek.Monday);
        DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);
    
        var defaultOpeningHours = await _context.DefaultOpeningHours
            .Where(e => e.FacilityId == facilityId)
            .ToListAsync();
        
        var specialOpeningHours = await _context.SpecialOpeningHours
            .Where(e => e.FacilityId == facilityId)
            .Where(e => e.Date >= DateOnly.FromDateTime(firstDayOfWeek) && 
                        e.Date <= DateOnly.FromDateTime(lastDayOfWeek))
            .ToListAsync();

        List<OpeningHoursBase> weeklyOpeningHours = new List<OpeningHoursBase>();
        
        for (int i = 0; i < 7; i++)
        {
            var currentDay = firstDayOfWeek.AddDays(i);
            var currentDayDateOnly = DateOnly.FromDateTime(currentDay);
        
            var specialHoursForDay = specialOpeningHours.FirstOrDefault(e => e.Date == currentDayDateOnly);

            if (specialHoursForDay != null)
            {
                weeklyOpeningHours.Add(specialHoursForDay);
            }
            else
            {
                var dayOfWeek = (int)currentDay.DayOfWeek;
                var defaultHoursForDay = defaultOpeningHours.FirstOrDefault(e => (int)e.WeekDay == dayOfWeek);

                if (defaultHoursForDay != null)
                {
                    weeklyOpeningHours.Add(defaultHoursForDay);
                }
            }
        }
    
        return Ok(weeklyOpeningHours);
    }
}