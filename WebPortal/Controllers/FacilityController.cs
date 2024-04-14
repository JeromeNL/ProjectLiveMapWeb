using BusinessLogic;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPortal.Models;

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
        _context.Facilities.Add(facility);
        await _context.SaveChangesAsync();

        foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
        {
            var openingHour = new DefaultOpeningHours(day)
            {
                FacilityId = facility.Id,
                OpenTime = new TimeOnly(0, 0),  
                CloseTime = new TimeOnly(23, 59) 
            };
            _context.DefaultOpeningHours.Add(openingHour);
        }
        await _context.SaveChangesAsync(); 

        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Show(int id)
    {
        var facility = await _context.Facilities
            .Include(f => f.DefaultOpeningHours) 
            .FirstOrDefaultAsync(f => f.Id == id);
        
        if (facility == null) return NotFound();
      
        var viewModel = new FacilityViewModel
        {
            Facility = facility,
            OpeningHours = facility.DefaultOpeningHours.OrderBy(oh => oh.WeekDay).ToList() 
        };
    
        return View(viewModel);
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