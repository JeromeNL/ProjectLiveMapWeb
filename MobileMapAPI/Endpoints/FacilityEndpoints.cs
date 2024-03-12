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
            // Verwerk hier de ontvangen data
            return Results.Ok($"Faciliteit {data.Name} met ID {data.FacilityId} ontvangen.");
        });
        // Je kunt hier meer facility-gerelateerde endpoints toevoegen
    }
}