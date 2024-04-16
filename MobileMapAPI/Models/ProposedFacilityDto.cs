using DataAccess.Models;

namespace MobileMapAPI.Models;

public class ProposedFacilityDto : ProposedFacility
{
    public int UserId { get; set; }
}