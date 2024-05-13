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
        var id = Guid.NewGuid();
        var user = await Context.Users.FindAsync(userId);
        var resort = await Context.HolidayResorts.FindAsync(ResortId);
        var pointsOfUser = await Context.PointsTransactions.Select(t => t.Amount).SumAsync();
        const string returnTo = nameof(Index);

        if (price <= 0)
        {
            TempData["ErrorMessage"] = "De opgegeven prijs is 0 of lager, vul een hogere prijs in";
            return RedirectToAction(returnTo);
        }

        if (pointsOfUser < price)
        {
            TempData["ErrorMessage"] = $"{user.Name} heeft niet genoeg punten om deze voucher te kopen";
            return RedirectToAction(returnTo);
        }

        if (user == null && resort == null)
        {
            TempData["ErrorMessage"] = "Gekozen gebruiker bestaat niet voor dit vakantiepark";
            return RedirectToAction(returnTo);
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