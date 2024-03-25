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
            .Include(report => report.Facility)
            .Include(report => report.ProposedFacilityChange)
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
            .Include(r => r.ProposedFacilityChange)
            .Include(r => r.Facility)
            .FirstOrDefaultAsync(r => r.Id == id);
        if (report == null) return NotFound();

        var proposedFacilityChange = report.ProposedFacilityChange;
        var facility = report.Facility;
        if (proposedFacilityChange != null)
        {
            // Apply changes from ProposedFacilityChange to Facility
            facility.Name = proposedFacilityChange.Name;
            facility.Description = proposedFacilityChange.Description;
            facility.Type = proposedFacilityChange.Type;
            facility.Latitude = proposedFacilityChange.Latitude;
            facility.Longitude = proposedFacilityChange.Longitude;
            facility.IconName = proposedFacilityChange.IconUrl;
        }

        report.Status = FacilityReportStatus.Accepted;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}