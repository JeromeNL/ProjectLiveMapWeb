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
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Facility facility)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        _context.Facilities.Add(facility);
        await _context.SaveChangesAsync();
        return Ok(facility);
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

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var facility = await _context.Facilities.FindAsync(id);
    
        if (facility == null)
        {
            return Json($"Geen faciliteit gevonden met ID {id}.");
        }
        
        _context.Facilities.Remove(facility);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }
}