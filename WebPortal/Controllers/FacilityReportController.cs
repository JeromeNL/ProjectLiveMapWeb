using DataAccess;
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
            .Where(report => report.Status == FacilityReportStatus.Pending).Include(report => report.Facility)
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
        var report = await _context.FacilityReports.FindAsync(id);
        if (report == null) return NotFound();
        var facility = await _context.Facilities.FindAsync(report.FacilityId);
        if (facility == null) return NotFound();
        
        report.Status = FacilityReportStatus.Accepted;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}