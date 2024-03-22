using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Validation;

namespace DataAccess.Models;

public class Facility
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Vul een naam in")]
    [MaxLength(100, ErrorMessage = "De ingevulde naar mag maximaal 100 karakters lang zijn")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Vul een beschrijving in")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Vul een type in")]
    public string Type { get; set; }

    [Required]
    [PolygonValidation(ErrorMessage = "Het aangegeven punt ligt buiten het park")]
    public double Latitude { get; set; }
    
    [Required]
    public double Longitude { get; set; }

    [Required(ErrorMessage = "Vul een Icoon URL in")]
    public string IconUrl { get; set; }
}