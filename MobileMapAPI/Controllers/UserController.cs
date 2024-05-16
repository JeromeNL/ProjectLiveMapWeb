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
        var user = context.Users.FirstOrDefault(u => u.Name == name);

        if (user == null)
        {
            return NotFound("User not found");
        }

        return Ok(user);
    }

    [HttpGet("{userId:int}/service-reports")]
    public async Task<IActionResult> GetSubmittedServiceReports(int userId)
    {
        var serviceReports = await context.ServiceReports
            .Include(report => report.Facility)
            .Include(report => report.User)
            .Where(report => report.UserId == userId).ToListAsync();
        return Ok(serviceReports);
    }

    [HttpGet("{userId:int}/facility-reports")]
    public async Task<IActionResult> GetSubmittedFacilityReports(int userId)
    {
        var facilityReports = await context.FacilityReports
            .Include(report => report.ProposedFacility)
            .Include(report => report.User)
            .Where(report => report.UserId == userId).ToListAsync();
        return Ok(facilityReports);
    }

    [HttpGet("{userId:int}/points/total")]
    public async Task<IActionResult> GetTotalPoints(int userId, int resortId)
    {
        var user = await context.Users
            .Include(u => u.PointsTransactions)
            .FirstOrDefaultAsync(u => u.Id == userId);
        
        if (user == null)
        {
            return NotFound("User not found");
        }

        return Ok(user.GetTotalPoints(resortId));
    }

    [HttpGet("{userId:int}/points/awarded")]
    public async Task<IActionResult> GetAwardedPointsOverview(int userId, int resortId)
    {
        var user = await context.Users.FindAsync(userId);

        if (user == null)
        {
            return NotFound("User not found");
        }
        
        var transactions = await context.PointsTransactions
            .Where(transaction => transaction.UserId == userId)
            .Where(transaction => transaction.HolidayResortId == resortId)
            .Where(transaction =>  transaction.Amount > 0)
            .Include(transaction => transaction.FacilityReport)
            .Include(transaction => transaction.ServiceReport)
            .ToListAsync();
        
        return Ok(transactions);
    }

    [HttpGet("{userId:int}/points/deducted")]
    public async Task<IActionResult> GetDeductedPointsOverview(int userId, int resortId)
    {
        var user = await context.Users.FindAsync(userId);

        if (user == null)
        {
            return NotFound("User not found");
        } 
        
        var transactions = await context.PointsTransactions
            .Where(transaction => transaction.UserId == userId)
            .Where(transaction => transaction.HolidayResortId == resortId)
            .Where(transaction => transaction.Amount < 0)
            .Include(transaction => transaction.FacilityReport)
            .Include(transaction => transaction.ServiceReport)
            .ToListAsync();

        return Ok(transactions);
    }
}