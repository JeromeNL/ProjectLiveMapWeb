using DataAccess;
using DataAccess.Models;
using MobileMapAPI.ApiModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public static class FacilityEndpoints
{
    public static void MapFacilityEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/facility/requestchange", async (LiveMapDbContext context, FacilityReportApiModel data) =>
        {
            
            var facility = new Facility()
            {
                
                Name = data.Name,
                Description = data.Description,
                Type = data.Type,
                IconUrl = data.IconUrl,
                Latitude = data.Latitude,
                Longitude = data.Longitude
               
            };
            
            context.Facilities.Add(facility);
            await context.SaveChangesAsync();

            return Results.Ok($"Facility {data.Name} with ID {facility.Id} received and saved in the database.");
        });
    }
}