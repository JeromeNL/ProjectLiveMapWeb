using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class Fault
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string title { get; set; }
    
    [Required]
    public string description { get; set; }
    
    [Required]
    public string type { get; set; }
    
    [Required]
    public int facilityId { get; set; }
    
    [ForeignKey(nameof(facilityId))]
    public Facility Facility { get; set; }
}