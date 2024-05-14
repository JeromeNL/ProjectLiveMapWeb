using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class User
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [NotMapped]
    public int TotalPoints => PointsTransactions.Sum(t => t.Amount);
    
    public IEnumerable<PointsTransaction> PointsTransactions { get; } = new List<PointsTransaction>();
}