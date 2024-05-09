using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPortal.Controllers.Base;

namespace WebPortal.Controllers;

public class ServiceReportController(LiveMapDbContext context) : LivemapController
{
    public async Task<IActionResult> Index()
    {
        var reports = await context.ServiceReports
            .Where(f => f.HolidayResortId == ResortId)
            .Include(r => r.ServiceReportCategory)
            .Include(r => r.Facility)
            .Include(r => r.User)
            .ToListAsync();
        return View(reports);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id, int points)
    {
        var report = await context.ServiceReports.FindAsync(id);
        if (report == null) return RedirectToAction("Index");

        context.ServiceReports.Remove(report);
        TempData["InfoMessage"] = "Service melding " + report.Id + " is gesloten.";

        var transaction = new PointsTransaction()
        {
            Amount = points,
            FacilityReportId = null,
            FacilityReport = null,
            ServiceReportId = id,
            ServiceReport = report,
            UserId = report.UserId,
            User = report.User,
            HolidayResortId = report.HolidayResortId,
            HolidayResort = report.HolidayResort,
            VoucherId = null,
            Voucher = null
        };

        await context.PointsTransactions.AddAsync(transaction);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}