using Microsoft.AspNetCore.Mvc;

namespace WebPortal.Controllers;

public class FacilityReportController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}