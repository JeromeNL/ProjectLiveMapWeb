using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("users")]
public class UserController(LiveMapDbContext context) : ControllerBase
{
    [HttpPost("{name}")]
    public IActionResult PostUserByName(string name)
    {
        var user = context.Users.FirstOrDefault(u => u.UserName == name);

        if (user == null)
        {
            return NotFound("ApplicationUser not found");
        }

        return Ok(user);
    }

    [HttpGet("{userId:guid}/service-reports")]
    public async Task<IActionResult> GetSubmittedServiceReports(Guid userId)
    {
        var serviceReports = await context.ServiceReports
            .Include(report => report.Facility)
            .Include(report => report.User)
            .Where(report => report.UserId == userId.ToString()).ToListAsync();
        return Ok(serviceReports);
    }

    [HttpGet("{userId:guid}/facility-reports")]
    public async Task<IActionResult> GetSubmittedFacilityReports(Guid userId)
    {
        var facilityReports = await context.FacilityReports
            .Include(report => report.ProposedFacility)
            .Include(report => report.ApplicationUser)
            .Where(report => report.UserId == userId.ToString()).ToListAsync();
        return Ok(facilityReports);
    }

    [HttpGet("{userId:guid}/points/total")]
    public async Task<IActionResult> GetTotalPoints(Guid userId, int resortId)
    {
        var user = await context.Users
            .Include(u => u.PointsTransactions)
            .FirstOrDefaultAsync(u => u.Id == userId.ToString());
        
        if (user == null)
        {
            return NotFound("ApplicationUser not found");
        }

        return Ok(user.GetTotalPoints(resortId));
    }

    [HttpGet("{userId:guid}/points/transactions")]
    public async Task<IActionResult> GetPointsTransactionsOverview(string userId, int resortId)
    {
        var user = await context.Users.FindAsync(userId);

        if (user == null)
        {
            return NotFound("User not found");
        }
        
        var transactions = await context.PointsTransactions
            .Where(transaction => transaction.UserId == userId)
            .Where(transaction => transaction.HolidayResortId == resortId)
            .Include(transaction => transaction.FacilityReport)
            .Include(transaction => transaction.ServiceReport)
            .Include(transaction => transaction.Voucher)
            .ToListAsync();
        
        return Ok(transactions);
    }
}