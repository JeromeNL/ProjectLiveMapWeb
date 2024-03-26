using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Interfaces;
using DataAccess.Models.Base;


namespace DataAccess.Models;

public class Facility : FacilityBase, ISoftDelete

{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }
}