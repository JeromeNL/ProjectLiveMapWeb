using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebPortal.Controllers;

public class FacilityReportController : Controller
{
    private readonly LiveMapDbContext _context;

    public FacilityReportController(LiveMapDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var pendingReports = await _context.FacilityReports
            .Where(report => report.Status == FacilityReportStatus.Pending)
            .Include(report => report.ProposedFacility.Facility)
            .Include(report => report.ProposedFacility)
            .OrderBy(report => report.CreatedAt).ToListAsync();
            
        return View(pendingReports);
    }

    public async Task<IActionResult> DenyReport(int id)
    {
        var report = await _context.FacilityReports.FindAsync(id);
        if (report == null) return NotFound();

        report.Status = FacilityReportStatus.Denied;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> ApproveReport(int id)
    {
        var report = await _context.FacilityReports
            .Include(r => r.ProposedFacility)
            .Include(r => r.ProposedFacility.Facility)
            .FirstOrDefaultAsync(r => r.Id == id);
        if (report == null) return NotFound();

        var proposedFacilityChange = report.ProposedFacility;
        var facility = report.ProposedFacility.Facility;


        // new facility to add instead of existing facility.
        if (report.ProposedFacility.FacilityId == null)
        {
            var newFacility = new Facility
            {
                Name = report.ProposedFacility.Name,
                Description = report.ProposedFacility.Description,
                Longitude = report.ProposedFacility.Longitude,
                Latitude = report.ProposedFacility.Latitude,
                Type = report.ProposedFacility.Type,
                IconName = report.ProposedFacility.IconName,
            };

            await _context.Facilities.AddAsync(newFacility);

        }
        else
        {
            if (proposedFacilityChange != null)
            {
                // Apply changes from ProposedFacilityChange to Facility
                facility.Name = proposedFacilityChange.Name;
                facility.Description = proposedFacilityChange.Description;
                facility.Type = proposedFacilityChange.Type;
                facility.Latitude = proposedFacilityChange.Latitude;
                facility.Longitude = proposedFacilityChange.Longitude;
                facility.IconName = proposedFacilityChange.IconName;
                
            }
        }
        report.Status = FacilityReportStatus.Accepted;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}