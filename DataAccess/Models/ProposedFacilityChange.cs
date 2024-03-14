﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class ProposedFacilityChange
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [MaxLength(100)] 
    public string Name { get; set; }

    [Required] 
    public string Description { get; set; }

    [Required] 
    public string Type { get; set; }

    [Required] 
    public double Latitude { get; set; }

    [Required] 
    public double Longitude { get; set; }

    [Required] 
    public string IconUrl { get; set; }
}