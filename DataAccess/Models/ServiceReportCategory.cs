using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAccess.Models;
public class ServiceReportCategory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Het naam veld is verplicht")]
    public string Name { get; set; }
    
    [Required]
    public int HolidayResortId { get; set; }
    
    [ForeignKey(nameof(HolidayResortId))]
    [JsonIgnore]
    public HolidayResort? HolidayResort { get; set; }
}