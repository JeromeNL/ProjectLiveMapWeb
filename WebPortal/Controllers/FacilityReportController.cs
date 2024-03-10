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

    public IActionResult Index()
    {
        var reports = _context.FacilityReports.Include(report => report.Facility).OrderBy(report => report.CreatedAt).ToList();
        return View(reports);
    }
}