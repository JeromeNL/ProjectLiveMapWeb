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
            ;
            var facility = new Facility();
            
            facility.Name = data.Name;
            facility.Description = data.Description;
            facility.Type = data.Type;
            facility.IconUrl = data.IconUrl;
            facility.Latitude = data.Latitude;
            facility.Longitude = data.Longitude;
            
            facilityReport.FacilityId = data.FacilityId;
            facilityReport.Description = data.Description;
            facilityReport.CreatedAt = DateTime.Now;
            facilityReport.Status = FacilityReportStatus.Pending;
            facilityReport.Facility = facility;

            context.FacilityReports.Add(facilityReport);
            await context.SaveChangesAsync();

            return Results.Ok($"Facility {facilityReport.Facility.Name} with ID {facilityReport.Id} updated in the database.");
        });
    }
}