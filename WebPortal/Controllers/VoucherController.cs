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
        const string key = "ErrorMessage";
        string returnTo = nameof(Index);
        var id = Guid.NewGuid();
        var user = await Context.Users.FindAsync(userId);
        if (user == null)
        {
            TempData[key] = "Gekozen gebruiker bestaat niet voor dit vakantiepark";
            return RedirectToAction(returnTo);
        }

        var resort = await Context.HolidayResorts.FindAsync(ResortId);
        if (resort == null)
        {
            TempData[key] = "Gekozen gebruiker bestaat niet voor dit vakantiepark";
            return RedirectToAction(returnTo);
        }

        returnTo = nameof(Create);
        var pointsOfUser = await Context.PointsTransactions.Where(p => p.UserId == userId).Select(t => t.Amount)
            .SumAsync();
        if (price <= 0)
        {
            TempData[key] = "De opgegeven prijs is 0 of lager, vul een hogere prijs in";
            return RedirectToAction(returnTo);
        }

        if (pointsOfUser < price)
        {
            TempData[key] = $"{user.Name} heeft niet genoeg punten om deze voucher te kopen";
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
            UserId = userId,
            User = user,
            HolidayResortId = ResortId,
            HolidayResort = resort,
            VoucherId = id,
            Voucher = voucher
        };

        await Context.PointsTransactions.AddAsync(transaction);
        await Context.SaveChangesAsync();
        
        TempData["SuccessMessage"] = $"Vocher '{voucher.Description}' voor {user.Name} aangemaakt";
        
        return RedirectToAction("Index");
    }
}