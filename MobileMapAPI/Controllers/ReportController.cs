using DataAccess;
using DataAccess.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("reports")]
public class ReportController(LiveMapDbContext context) : ControllerBase
{
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetSubmittedReportsByUser(int userId)
    {
        var facilityReports = await context.FacilityReports
            .Include(report => report.ProposedFacility)
            .Include(report => report.User)
            .Where(report => report.UserId == userId).ToListAsync();
        return Ok(facilityReports);
    }

    [HttpPatch("{reportId:int}/cancel")]
    public async Task<IActionResult> CancelReport(int reportId)
    {
        var facilityReport = await context.FacilityReports.FindAsync(reportId);

        if (facilityReport == null)
        {
            return NotFound("Report not found");
        }

        facilityReport.Status = FacilityReportStatus.Cancelled;
        await context.SaveChangesAsync();
        return Ok("Report has been succesfully cancelled");
    }
}