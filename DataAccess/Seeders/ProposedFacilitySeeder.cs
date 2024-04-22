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
                Name = facility.Name,
                CategoryId = facility.CategoryId,
                Description = facility.Description,
                Latitude = facility.Latitude,
                Longitude = facility.Longitude,
                FacilityId = facility.Id,
                HolidayResortId = 1,
            };
            proposedFacilities.Add(proposedFacility);
        }
        // new proposed facility
        var newProposedFacility = new ProposedFacility
        {
            Id = 4,
            Name = "Zwemzee",
            CategoryId = 1,
            Description = "De nieuwe zwemzee",
            Latitude = 51.651976894252684,
            Longitude = 5.053454583354487,
            HolidayResortId = 1,
        };
        proposedFacilities.Add(newProposedFacility);
        
        return proposedFacilities;
    }
}