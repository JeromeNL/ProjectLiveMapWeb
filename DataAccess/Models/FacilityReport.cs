using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class FacilityReport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public int FacilityId { get; set; }
    
    [Required]
    public Facility Facility { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
}