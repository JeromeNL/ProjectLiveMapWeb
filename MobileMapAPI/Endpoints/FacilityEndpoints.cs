// FacilityEndpoints.cs
using MobileMapAPI.ApiModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public static class FacilityEndpoints
{
    public static void MapFacilityEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/facility/requestchange", (FacilityReportApiModel data) =>
        {
            return Results.Ok($"Facility {data.Name} with ID {data.FacilityId} received!.");
        });
    }
}