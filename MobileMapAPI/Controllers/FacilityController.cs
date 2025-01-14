using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileMapAPI.Models;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("resorts/{resortId:int}/facilities")]
public class FacilityController(LiveMapDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllFacilities(int resortId)
    {
        var today = DateTime.Today;
        var monday = DateOnly.FromDateTime(today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday));
        var sunday = monday.AddDays(6);

        var facilities = await context.Facilities
            .Where(f => f.HolidayResortId == resortId)
            .Include(f => f.Category)
            .Include(f => f.ServiceReports)
            .Include(x => x.DefaultOpeningHours)
            .Include(x => x.SpecialOpeningHours.Where(s => s.Date >= monday && s.Date <= sunday))
            .ToListAsync();
        
        return Ok(facilities);
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetAllCategories(int resortId)
    {
        var categories = await context.FacilityCategories
            .Where(f => f.HolidayResortId == resortId)
            .ToListAsync();
        return Ok(categories);
    }

    [HttpPost("upsert")]
    public async Task<IActionResult> RequestFacilityChange(ProposedFacilityDto data, int resortId)
    {
        int? existingFacilityId = null;
        if (data.FacilityId != null)
        {
            var existingFacility = await context.Facilities.FindAsync(data.FacilityId);

            if (existingFacility == null)
            {
                return NotFound($"Facility with ID {data.Id} not found.");
            }

            existingFacilityId = existingFacility.Id;
        }

        var proposedFacilityChange = new ProposedFacility
        {
            FacilityId = existingFacilityId,
            Name = data.Name,
            Description = data.Description,
            CategoryId = data.CategoryId,
            Latitude = data.Latitude,
            Longitude = data.Longitude,
            HolidayResortId = resortId,
        };

        var facilityReport = new FacilityReport
        {
            Description = data.Description,
            UserId = data.UserId,
            CreatedAt = DateTime.Now,
            Status = ReportStatus.Pending,
            ProposedFacility = proposedFacilityChange,
            HolidayResortId = resortId,
        };

        await context.FacilityReports.AddAsync(facilityReport);
        await context.SaveChangesAsync();

        return Ok("Your report has been saved in the database.");
    }
}