using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class ApplicationUser
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    public IEnumerable<PointsTransaction> PointsTransactions { get; } = new List<PointsTransaction>();
    
    public int GetTotalPoints(int resortId)
    {
        return PointsTransactions
            .Where(pt => pt.HolidayResortId == resortId)
            .Sum(pt => pt.Amount);
    }
}