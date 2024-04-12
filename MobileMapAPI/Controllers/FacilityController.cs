using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
        var facilities = await _context.Facilities.Include(f => f.Category).ToListAsync();
        if (facilities.IsNullOrEmpty())
        {
            return NotFound("No facilities were found");
        }
        return Ok(facilities);
    }

    [HttpGet("/categories")]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _context.FacilityCategories.ToListAsync();
        return Ok(categories);
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
            CategoryId = data.CategoryId,
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
