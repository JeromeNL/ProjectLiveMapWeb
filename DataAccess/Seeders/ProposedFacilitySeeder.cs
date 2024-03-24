using DataAccess.Models;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class ProposedFacilitySeeder(List<Facility> facilities) : ISeeder<ProposedFacility>
{
    public List<ProposedFacility> Seed()
    {
        var proposedFacilities = new List<ProposedFacility>();
        var id = 1;
        foreach (var facility in facilities)
        {
            var proposedFacility = new ProposedFacility
            {
                Id = id++,
                FacilityId = facility.Id,
                Name = facility.Name,
                Type = facility.Type,
                Description = facility.Description,
                Latitude = facility.Latitude,
                Longitude = facility.Longitude,
                IconName = facility.IconName
            };
            proposedFacilities.Add(proposedFacility);
        }
        return proposedFacilities;
    }
}