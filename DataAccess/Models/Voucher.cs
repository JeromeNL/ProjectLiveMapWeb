using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class Voucher
{
    [Key] public Guid Id { get; set; }
    [Required] public bool Redeemed { get; set; }
    [Required] public string Description { get; set; }
}