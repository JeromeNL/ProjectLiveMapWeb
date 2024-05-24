using Microsoft.AspNetCore.Identity;

namespace DataAccess.Models;

public class ApplicationUser : IdentityUser
{
    public IEnumerable<PointsTransaction> PointsTransactions { get; } = new List<PointsTransaction>();
    
    public int GetTotalPoints(int resortId)
    {
        return PointsTransactions
            .Where(pt => pt.HolidayResortId == resortId)
            .Sum(pt => pt.Amount);
    }
}