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
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Facility facility)
    {
        if (!ModelState.IsValid) return View(facility);
        
        _context.Facilities.Add(facility);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    [Route("facility/{id:int}")]
    public IActionResult Show(int id)
    {
        var facility = _context.Facilities.Find(id);
        if (facility == null) return NotFound();
        
        return View(facility);
    }
}