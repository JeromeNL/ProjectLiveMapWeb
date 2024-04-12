using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace WebPortal.Controllers;

public class ServiceReportCategoryController(LiveMapDbContext context) : Controller
{
    public IActionResult Index()
    {
        return View(context.ServiceReportCategories.ToList());
    }
    public IActionResult Delete(int id)
    {
        var category = context.ServiceReportCategories.Find(id);
        if (category == null)
        {
            return RedirectToAction("Index");
        }

        context.ServiceReportCategories.Remove(category);
        context.SaveChanges();
        return RedirectToAction("Index");
    }
}