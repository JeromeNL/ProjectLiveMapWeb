﻿using BusinessLogic;
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
        var facilities = _context.Facilities.Include(f => f.Category).ToList();
        return View(facilities);
    }

    [HttpGet]
    public async Task<IActionResult> Create(double latitude, double longitude)
    {
        if (!ValidationLogic.IsPointInsidePolygon(latitude, longitude))
        {
            ViewBag.message = "het geklikte punt ligt niet binnen het park";
            var facilities = _context.Facilities.ToList();
            return View("Index", facilities);
        }

        var facilityCategories = await _context.FacilityCategories.ToListAsync();
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
        ModelState.Remove("Facility.IconName");
        if (!ModelState.IsValid)
        {
            viewModel.FacilityCategories = await _context.FacilityCategories.ToListAsync();
            viewModel.Latitude = viewModel.Facility.Latitude;
            viewModel.Longitude = viewModel.Facility.Longitude;
            viewModel.Facility.IconName = "empty";
        }
        
        var openingHours = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>()
            .Select(day => new DefaultOpeningHours(day)
            {
                Facility = viewModel.Facility,
                OpenTime = new TimeOnly(0, 0), // Begin tijd op 00:00
                CloseTime = new TimeOnly(23, 59) // Eind tijd op 23:59
            }).ToList();
        
        _context.Facilities.Add(viewModel.Facility);
        
        _context.AddRange(openingHours);
        
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Show(int id)
    {
       
        var facility = await _context.Facilities
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