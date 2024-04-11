﻿using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("serviceReports")]
public class ServiceReportController : ControllerBase
{
    private readonly LiveMapDbContext _context;

    public ServiceReportController(LiveMapDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFaults()
    {
        var serviceReports = await _context.ServiceReports.ToListAsync();

        if (serviceReports.IsNullOrEmpty())
        {
            return NotFound("No service reports were found");
        }
        
        return Ok(serviceReports);
    }

    [HttpPost]
    public async Task<IActionResult> AddFault(ServiceReport data)
    {
        var belongsTo = await _context.Facilities.FindAsync(data.facilityId);

        if (belongsTo == null)
        {
            return NotFound("Could not find provided Facility");
        }
        
        var newFault = new ServiceReport()
        {
            title = data.title,
            description = data.description,
            type = data.type,
            facilityId = data.facilityId,
            Facility = belongsTo
        };

        await _context.ServiceReports.AddAsync(newFault);
        await _context.SaveChangesAsync();

        return Ok("New service report has been saved");
    }
}