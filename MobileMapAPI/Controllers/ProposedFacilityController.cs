using Microsoft.AspNetCore.Mvc;
using MobileMapAPI.ApiModels;
using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Enums;
using System;
using System.Threading.Tasks;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProposedFacilityController : ControllerBase
{
    private readonly LiveMapDbContext _context;

    public ProposedFacilityController(LiveMapDbContext context)
    {
        _context = context;
    }

    [HttpPost("request")]
    public async Task<IActionResult> RequestFacilityChange(FacilityReportApiModel data)
    {
        var existingFacility = await _context.Facilities.FindAsync(data.FacilityId);
        
        if (existingFacility == null)
        {
            return NotFound($"Facility with ID {data.FacilityId} not found.");
        }
        
        var proposedFacilityChange = new ProposedFacilityChange
        {
            Name = data.Name,
            Description = data.Description,
            Type = data.Type,
            IconUrl = data.IconUrl,
            Latitude = data.Latitude,
            Longitude = data.Longitude
        };

        var facilityReport = new FacilityReport
        {
            FacilityId = data.FacilityId,
            Description = data.Description, 
            CreatedAt = DateTime.Now,
            Status = FacilityReportStatus.Pending,
            ProposedFacilityChange = proposedFacilityChange,
            Facility = existingFacility
        };

        _context.FacilityReports.Add(facilityReport);
        await _context.SaveChangesAsync();

        return Ok($"A report for {facilityReport.Facility.Name} with ID {facilityReport.Id} has been saved in the database.");
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProposedFacility(FacilityApiModel data)
    {
        var facility = new ProposedFacility()
        {
            Description = data.Description,
            IconUrl = data.IconUrl,
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
