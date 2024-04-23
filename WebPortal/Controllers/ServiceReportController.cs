using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebPortal.Controllers;

public class ServiceReportController(LiveMapDbContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var reports = await context.ServiceReports
            .Include(r => r.ServiceReportCategory)
            .Include(r => r.Facility)
            .Include(r => r.User)
            .ToListAsync();
        return View(reports);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var report = await context.ServiceReports.FindAsync(id);
        if (report == null) return RedirectToAction("Index");

        context.ServiceReports.Remove(report);
        await context.SaveChangesAsync();
        TempData["InfoMessage"] = "Service melding " + report.Id + " is gesloten." ;
        return RedirectToAction("Index");
    }
}