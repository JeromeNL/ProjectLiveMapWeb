﻿using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPortal.Controllers.Base;
using WebPortal.Models;

namespace WebPortal.Controllers;

[Authorize(Roles = $"{nameof(Role.ResortEmployee)}, {nameof(Role.ResortAdmin)}, {nameof(Role.SuperAdmin)}")]
public class FacilityController(LiveMapDbContext context) : LivemapController
{
    // GET
    public IActionResult Index()
    {
        var facilities = context.Facilities
            .Where(f => f.HolidayResortId == ResortId)
            .Include(f => f.Category)
            .ToList();
        var resort = context.HolidayResorts.Find(ResortId);

        var viewModel = new FacilityIndexViewModel
        {
            Facilities = facilities,
            Resort = resort
        };

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Create(double latitude, double longitude)
    {
        var resort = await context.HolidayResorts.FindAsync(ResortId);

        if (resort == null)
        {
            return NotFound();
        }

        if (!resort.IsPointInside(latitude, longitude))
        {
            TempData["ErrorMessage"] = "Klik binnen het park om een faciliteit toe te voegen.";
            return RedirectToAction(nameof(Index));
        }

        var facilityCategories = await context.FacilityCategories
            .Where(f => f.HolidayResortId == ResortId)
            .ToListAsync();

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
        TempData["SuccessMessage"] = "Faciliteit " + viewModel.Facility.Name + " is aangemaakt.";
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
            OpeningHours = facility.DefaultOpeningHours.OrderBy(oh => oh.WeekDay).ToList(),
            IsAlwaysOpen = facility.IsAlwaysOpen()
        };

        return View(viewModel);
    }

    public async Task<IActionResult> SwitchIsAlwaysOpen(int id)
    {
        var facility = await context.Facilities
            .Include(f => f.DefaultOpeningHours)
            .Include(f => f.Category)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (facility == null)
        {
            RedirectToAction("Index");
        }

        if (facility.IsAlwaysOpen())
        {
            facility.SetToRegularOpeningHours();
        }
        else
        {
            facility.SetAlwaysOpen();
        }

        context.Facilities.Update(facility);
        await context.SaveChangesAsync();

        return RedirectToAction("Show", new { id = facility.Id });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var facility = await context.Facilities.FindAsync(id);

        if (facility == null)
        {
            return Json($"Geen faciliteit gevonden met ID {id}.");
        }

        TempData["InfoMessage"] = "Faciliteit " + facility.Name + " is verwijderd.";
        context.Facilities.Remove(facility);
        await context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}