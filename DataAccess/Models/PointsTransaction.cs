using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class PointsTransaction
{
    [Key] public Guid Id { get; set; }

    [Required] [Range(-10, 10)] public int Amount { get; set; }

    [Required] public int HolidayResortId { get; set; }

    [ForeignKey(nameof(HolidayResortId))] public HolidayResort HolidayResort { get; set; }

    [Required] public int UserId { get; set; }

    [ForeignKey(nameof(UserId))] public User User { get; set; }

    public int? FacilityReportId { get; set; }

    [ForeignKey(nameof(FacilityReportId))] public FacilityReport? FacilityReport { get; set; }

    public int? ServiceReportId { get; set; }

    [ForeignKey(nameof(ServiceReportId))] public ServiceReport? ServiceReport { get; set; }

    //TODO: Add voucher id in US 104
}