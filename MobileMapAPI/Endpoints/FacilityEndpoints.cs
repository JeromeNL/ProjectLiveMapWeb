using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Enums;
using MobileMapAPI.ApiModels;

public static class FacilityEndpoints
{
    public static void MapFacilityEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/facility/requestchange", async (LiveMapDbContext context, FacilityReportApiModel data) =>
        {
            var existingFacility = await context.Facilities.FindAsync(data.FacilityId);
            var facilityReport = new FacilityReport();
            
            if (existingFacility == null)
            {
                return Results.NotFound($"Facility with ID {data.FacilityId} not found.");
            }
            
            var ProposedFacilityChange = new ProposedFacilityChange();
            
            ProposedFacilityChange.Name = data.Name;
            ProposedFacilityChange.Description = data.Description;
            ProposedFacilityChange.Type = data.Type;
            ProposedFacilityChange.IconUrl = data.IconUrl;
            ProposedFacilityChange.Latitude = data.Latitude;
            ProposedFacilityChange.Longitude = data.Longitude;
            
            facilityReport.FacilityId = data.FacilityId;
            facilityReport.Description = data.Description;
            facilityReport.CreatedAt = DateTime.Now;
            facilityReport.Status = FacilityReportStatus.Pending;
            facilityReport.ProposedFacilityChange = ProposedFacilityChange;
            facilityReport.Facility = existingFacility;

            context.FacilityReports.Add(facilityReport);
            await context.SaveChangesAsync();

            return Results.Ok($"A report for {facilityReport.Facility.Name} with ID {facilityReport.Id} as been saved in the database.");
        });
    }
}