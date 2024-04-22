using DataAccess.Models;
using DataAccess.Models.Enums;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class FacilityReportSeeder(List<ProposedFacility> proposedFacilities): ISeeder<FacilityReport>
{
    public List<FacilityReport> Seed()
    {
        var facilityReports = new List<FacilityReport>();
        var id = 1;
        foreach (var proposedFacility in proposedFacilities)
        {
            var facilityReport = new FacilityReport
            {
                Id = id++,
                ProposedFacilityId = proposedFacility.Id,
                Status = ReportStatus.Pending,
                Description = "Seed",
                CreatedAt = DateTime.Now,
                UserId = 1,
                HolidayResortId = 1,
            };
            facilityReports.Add(facilityReport);   
        }
        
        return facilityReports;
    }
}