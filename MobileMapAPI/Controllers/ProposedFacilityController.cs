using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("proposed-facilities")]
public class ProposedFacilityController : ControllerBase
{
    private readonly LiveMapDbContext _context;

    public ProposedFacilityController(LiveMapDbContext context)
    {
        _context = context;
    }

    [HttpPost("request")]
    public async Task<IActionResult> RequestFacilityChange(ProposedFacility data)
    {
        var existingFacility = await _context.Facilities.FindAsync(data.Id);
        
        if (existingFacility == null)
        {
            return NotFound($"Facility with ID {data.Id} not found.");
        }
        
        var proposedFacilityChange = new ProposedFacility
        {
            Name = data.Name,
            Facility = existingFacility,
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

        _context.FacilityReports.Add(facilityReport);
        await _context.SaveChangesAsync();

        return Ok($"A report for {facilityReport.ProposedFacility.Facility.Name} with ID {facilityReport.Id} has been saved in the database.");
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProposedFacility(ProposedFacility data)
    {
        var facility = new ProposedFacility()
        {
            Description = data.Description,
            IconName = data.IconName,
            Latitude = data.Latitude,
            Longitude = data.Longitude,
            Name = data.Name,
            Type = data.Type
        };

        _context.ProposedFacilities.Add(facility);
        await _context.SaveChangesAsync();
        
        return Ok("done");
    }
}
