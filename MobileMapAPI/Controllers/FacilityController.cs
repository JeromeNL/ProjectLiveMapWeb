using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("facilities")]
public class FacilityController : ControllerBase
{
    private readonly LiveMapDbContext _context;

    public FacilityController(LiveMapDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllFacilities()
    {
        var today = DateTime.Today;
        var monday = DateOnly.FromDateTime(today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday));
        var sunday = monday.AddDays(6);
        var facilities = await _context.Facilities
            .Include(x => x.DefaultOpeningHours)
            .Include(x => x.SpecialOpeningHours.Where(s => s.Date >= monday && s.Date <= sunday))
            .ToListAsync();
        return Ok(facilities);
    }
    
    [HttpPost("upsert")]
    public async Task<IActionResult> RequestFacilityChange(ProposedFacility data)
    {
        int? existingFacilityId = null;
        if (data.FacilityId != null)
        {
            var existingFacility = await _context.Facilities.FindAsync(data.FacilityId);
        
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
            Type = data.Type,
            IconName = data.IconName,
            Latitude = data.Latitude,
            Longitude = data.Longitude
        };

        var facilityReport = new FacilityReport
        {
            Description = data.Description, 
            CreatedAt = DateTime.Now,
            Status = FacilityReportStatus.Pending,
            ProposedFacility = proposedFacilityChange,
        };
        
        await _context.FacilityReports.AddAsync(facilityReport);
        await _context.SaveChangesAsync();

        return Ok($"Your report has been saved in the database.");
    }
}
