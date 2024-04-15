using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("facilities")]
public class FacilityController(LiveMapDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllFacilities()
    {
        var facilities = await context.Facilities.Include(f => f.ServiceReports).Include(f => f.Category).ToListAsync();
        if (facilities.IsNullOrEmpty())
        {
            return NotFound("No facilities were found");
        }

        var today = DateTime.Today;
        var monday = DateOnly.FromDateTime(today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday));
        var sunday = monday.AddDays(6);
        var facilities = await _context.Facilities
            .Include(x => x.DefaultOpeningHours)
            .Include(x => x.SpecialOpeningHours.Where(s => s.Date >= monday && s.Date <= sunday))
            .ToListAsync();
        return Ok(facilities);
    }

    [HttpGet("/categories")]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await context.FacilityCategories.ToListAsync();
        return Ok(categories);
    }

    [HttpPost("upsert")]
    public async Task<IActionResult> RequestFacilityChange(ProposedFacility data)
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
            Longitude = data.Longitude
        };

        var facilityReport = new FacilityReport
        {
            Description = data.Description,
            CreatedAt = DateTime.Now,
            Status = ReportStatus.Pending,
            ProposedFacility = proposedFacilityChange,
        };

        await context.FacilityReports.AddAsync(facilityReport);
        await context.SaveChangesAsync();

        return Ok($"Your report has been saved in the database.");
    }
}
