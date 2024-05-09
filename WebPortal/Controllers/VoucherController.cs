using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPortal.Controllers.Base;

namespace WebPortal.Controllers;

public class VoucherController(LiveMapDbContext Context) : LivemapController
{
    public async Task<IActionResult> Index()
    {
        var transactions = await Context.PointsTransactions.ToListAsync();
        return View(transactions);
    }
}