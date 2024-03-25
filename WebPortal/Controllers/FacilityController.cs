using BusinessLogic;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebPortal.Controllers;

public class FacilityController : Controller
{
    private readonly LiveMapDbContext _context;

    public FacilityController(LiveMapDbContext context)
    {
        _context = context;
    }

    // GET
    public IActionResult Index()
    {
        var facilities = _context.Facilities.ToList();
        return View(facilities);
    }
    
    [HttpGet]
    public IActionResult Create(double latitude, double longitude)
    {
        if (!ValidationLogic.IsPointInsidePolygon(latitude, longitude))
        {
            ViewBag.message = "het geklikte punt ligt niet binnen het park";
            var facilities = _context.Facilities.ToList();
            return View("Index", facilities);
        }
        ViewBag.latitude = latitude;
        ViewBag.longitude = longitude;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Facility facility)
    {
        if (!ModelState.IsValid)
        {
            return View(facility);
        }
        
        _context.Facilities.Add(facility);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Show(int id)
    {
        var facility = await _context.Facilities.FindAsync(id);
        if (facility == null) return NotFound();
        
        return View(facility);
    }

    [HttpGet]
    public IActionResult GetFacilitiesJson()
    {
        var facilities = _context.Facilities.ToList();
        return Json(facilities);
    }
}