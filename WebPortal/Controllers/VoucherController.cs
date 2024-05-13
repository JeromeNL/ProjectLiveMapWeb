using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPortal.Controllers.Base;

namespace WebPortal.Controllers;

public class VoucherController(LiveMapDbContext Context) : LivemapController
{
    public async Task<IActionResult> Index()
    {
        var transactions = await Context.PointsTransactions
            .Include(t => t.User)
            .Include(t => t.Voucher)
            .Where(t => t.Voucher != null)
            .ToListAsync();
        return View(transactions);
    }

    public async Task<IActionResult> Create()
    {
        var users = await Context.Users.ToListAsync();
        return View(users);
    }

    public async Task<IActionResult> Add(int userId, string description, int price)
    {
        //TODO: check if user has enough points
        var id = Guid.NewGuid();
        var user = await Context.Users.FindAsync(userId);
        var resort = await Context.HolidayResorts.FindAsync(ResortId);
        // var pointsOfUser = await Context.PointsTransactions.Select(t => t.Amount).Sum();
        if (user == null && resort == null)
        {
            return RedirectToAction("Index");
        }

        var voucher = new Voucher()
        {
            Id = id,
            Description = description,
            Redeemed = false
        };
        var transaction = new PointsTransaction()
        {
            Amount = price * -1,
            FacilityReportId = null,
            FacilityReport = null,
            ServiceReportId = null,
            ServiceReport = null,
            UserId = userId,
            User = user,
            HolidayResortId = ResortId,
            HolidayResort = resort,
            VoucherId = id,
            Voucher = voucher
        };

        await Context.PointsTransactions.AddAsync(transaction);
        await Context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}