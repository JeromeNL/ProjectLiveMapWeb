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
        var facilities = await context.Facilities.ToListAsync();
        if (facilities.IsNullOrEmpty())
        {
            return NotFound("No facilities were found");
        }
        return Ok(facilities);
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
            Type = data.Type,
            IconName = data.IconName,
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
