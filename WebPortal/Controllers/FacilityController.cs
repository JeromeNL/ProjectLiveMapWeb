using BusinessLogic;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPortal.Models;

namespace WebPortal.Controllers;

public class FacilityController(LiveMapDbContext context) : LivemapController
{
    // GET
    public IActionResult Index()
    {
        var facilities = context.Facilities
            .Where(f => f.HolidayResortId == ResortId)
            .Include(f => f.Category)
            .ToList();
        return View(facilities);
    }

    [HttpGet]
    public async Task<IActionResult> Create(double latitude, double longitude)
    {
        if (!ValidationLogic.IsPointInsidePolygon(latitude, longitude))
        {
            ViewBag.message = "het geklikte punt ligt niet binnen het park";
            var facilities = context.Facilities.ToList();
            return View("Index", facilities);
        }

        var facilityCategories = await context.FacilityCategories.ToListAsync();
        var viewModel = new FacilityCreateViewModel
        {
            Facility = new Facility(),
            FacilityCategories = facilityCategories,
            Latitude = latitude,
            Longitude = longitude
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(FacilityCreateViewModel viewModel)
    {
        ModelState.Remove("Facility.Category");
        if (!ModelState.IsValid)
        {
            viewModel.FacilityCategories = await context.FacilityCategories.ToListAsync();
            viewModel.Latitude = viewModel.Facility.Latitude;
            viewModel.Longitude = viewModel.Facility.Longitude;
        }
        
        var openingHours = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>()
            .Select(day => new DefaultOpeningHours(day)
            {
                Facility = viewModel.Facility,
                OpenTime = new TimeOnly(0, 0), 
                CloseTime = new TimeOnly(23, 59) 
            }).ToList();
        
        viewModel.Facility.HolidayResortId = ResortId;
        
        context.Facilities.Add(viewModel.Facility);
        
        context.AddRange(openingHours);
        
        await context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Show(int id)
    {
       
        var facility = await context.Facilities
            .Include(f => f.DefaultOpeningHours) 
            .Include(f => f.Category)
            .FirstOrDefaultAsync(f => f.Id == id);
        
        if (facility == null) return NotFound();
      
        var viewModel = new FacilityViewModel
        {
            Facility = facility,
            OpeningHours = facility.DefaultOpeningHours.OrderBy(oh => oh.WeekDay).ToList() 
        };
    
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var facility = await context.Facilities.FindAsync(id);
    
        if (facility == null)
        {
            return Json($"Geen faciliteit gevonden met ID {id}.");
        }
        
        context.Facilities.Remove(facility);
        await context.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }
}