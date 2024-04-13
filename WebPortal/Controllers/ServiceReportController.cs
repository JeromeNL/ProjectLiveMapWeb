using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace WebPortal.Controllers;

public class ServiceReportController(LiveMapDbContext context) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}