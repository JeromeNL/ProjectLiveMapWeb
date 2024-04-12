﻿using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebPortal.Controllers;

public class ServiceReportCategoryController(LiveMapDbContext context) : Controller
{
    public IActionResult Index()
    {
        return View(context.ServiceReportCategories.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Add(ServiceReportCategory category)
    {
        if (!ModelState.IsValid)
        {
            return View("Create", category);
        }
        context.ServiceReportCategories.Add(category);
        context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Edit(int id)
    {
        var category = context.ServiceReportCategories.Find(id);
        return View(category);
    }
    public IActionResult Update(ServiceReportCategory category)
    {
        if (!ModelState.IsValid)
        {
            return View("Edit", category);
        }
        var existingCategory = context.ServiceReportCategories.Find(category.Id);

        if (existingCategory == null) RedirectToAction("Index");

        existingCategory.Name = category.Name;
        context.SaveChanges();
        
        return RedirectToAction("Index");
    }
    public IActionResult Delete(int id)
    {
        var category = context.ServiceReportCategories.Find(id);
        if (category == null) return RedirectToAction("Index");

        context.ServiceReportCategories.Remove(category);
        context.SaveChanges();
        return RedirectToAction("Index");
    }
}