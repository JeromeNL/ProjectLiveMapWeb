using DataAccess;
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
        var reports = await _context.FacilityReports.Include(report => report.Facility).OrderBy(report => report.CreatedAt).ToListAsync();
        return View(reports);
    }
}