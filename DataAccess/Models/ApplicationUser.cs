using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Models;

public class ApplicationUser : IdentityUser
{
    public int? HolidayResortId { get; set; }
    
    [ForeignKey(nameof(HolidayResortId))]
    public HolidayResort? HolidayResort { get; set; }
    
    public IEnumerable<PointsTransaction> PointsTransactions { get; } = new List<PointsTransaction>();
    
    public int GetTotalPoints(int resortId)
    {
        return PointsTransactions
            .Where(pt => pt.HolidayResortId == resortId)
            .Sum(pt => pt.Amount);
    }
}