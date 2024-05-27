using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPortal.Controllers.Base;

namespace WebPortal.Controllers;

[Authorize(Roles = $"{nameof(Role.ResortEmployee)}, {nameof(Role.ResortAdmin)}")]
public class FacilityReportController(LiveMapDbContext context) : LivemapController
{
    public async Task<IActionResult> Index()
    {
        var pendingReports = await context.FacilityReports
            .Where(f => f.HolidayResortId == ResortId)
            .Where(report => report.Status == ReportStatus.Pending)
            .Include(report => report.ProposedFacility.Facility)
            .Include(report => report.ProposedFacility)
            .Include(report => report.ProposedFacility.Category)
            .Include(report => report.ProposedFacility.Facility.Category)
            .OrderBy(report => report.CreatedAt).ToListAsync();

        return View(pendingReports);
    }

    public async Task<IActionResult> DenyReport(int id)
    {
        var report = await context.FacilityReports.FindAsync(id);
        if (report == null) return NotFound();

        report.Status = ReportStatus.Denied;
        await context.SaveChangesAsync();
        TempData["InfoMessage"] = "Melding " + report.Id + " is afgekeurd.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> ApproveReport(int id, int points)
    {
        var report = await context.FacilityReports
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
                CategoryId = report.ProposedFacility.CategoryId,
                HolidayResortId = report.HolidayResortId
            };

            await context.Facilities.AddAsync(newFacility);
        }
        else
        {
            if (proposedFacilityChange != null)
            {
                // Apply changes from ProposedFacilityChange to Facility
                facility.Name = proposedFacilityChange.Name;
                facility.Description = proposedFacilityChange.Description;
                facility.CategoryId = proposedFacilityChange.CategoryId;
                facility.Latitude = proposedFacilityChange.Latitude;
                facility.Longitude = proposedFacilityChange.Longitude;
            }
        }

        report.Status = ReportStatus.Accepted;
        TempData["SuccessMessage"] = "Melding " + report.Id + " is goedgekeurd.";

        var transaction = new PointsTransaction()
        {
            Amount = points,
            FacilityReportId = id,
            FacilityReport = report,
            UserId = report.UserId,
            ApplicationUser = report.ApplicationUser,
            HolidayResortId = report.HolidayResortId,
            HolidayResort = report.HolidayResort,
        };

        await context.PointsTransactions.AddAsync(transaction);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}