using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class Voucher
{
    [Key] public Guid Id { get; set; }
    [Required] public bool Redeemed { get; set; }
    [Required] public int UserId { get; set; }
    [ForeignKey(nameof(UserId))] public User User { get; set; }
    [Required] public string Description { get; set; }
}