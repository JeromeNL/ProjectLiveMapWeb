using MobileMapAPI.ApiModels;

namespace MobileMapAPI.Endpoints;

using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Enums;

public static class FacilityEndpoints
{
    public static void MapFacilityEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/facility/requestchange", async (LiveMapDbContext context, FacilityReportApiModel data) =>
        {
            var existingFacility = await context.Facilities.FindAsync(data.FacilityId);
            
            if (existingFacility == null)
            {
                return Results.NotFound($"Facility with ID {data.FacilityId} not found.");
            }
            
            var proposedFacilityChange = new ProposedFacilityChange
            {
                Name = data.Name,
                Description = data.Description,
                Type = data.Type,
                IconUrl = data.IconUrl,
                Latitude = data.Latitude,
                Longitude = data.Longitude
            };

            var facilityReport = new FacilityReport
            {
                FacilityId = data.FacilityId,
                Description = data.Description,
                CreatedAt = DateTime.Now,
                Status = FacilityReportStatus.Pending,
                ProposedFacilityChange = proposedFacilityChange,
                Facility = existingFacility
            };


            context.FacilityReports.Add(facilityReport);
            await context.SaveChangesAsync();

            return Results.Ok($"A report for {facilityReport.Facility.Name} with ID {facilityReport.Id} has been saved in the database.");
        });

        app.MapPost("/facility/", async (LiveMapDbContext context, FacilityApiModel data) =>
        {
            var facility = new ProposedFacility()
            {
                Description = data.Description,
                IconUrl = data.IconUrl,
                Latitude = data.Latitude,
                Longitude = data.Longitude,
                Name = data.Name,
                Type = data.Type
            };

            context.ProposedFacilities.Add(facility);
            context.SaveChanges();
        });
    }
}