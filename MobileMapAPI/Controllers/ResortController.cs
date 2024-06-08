using System.Text.Json;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileMapAPI.Models;

namespace MobileMapAPI.Controllers;

[ApiController]
[Route("resorts")]
public class ResortController(LiveMapDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllResorts()
    {
        var resortDtos = new List<ResortDto>();
        var resorts = await context.HolidayResorts.ToListAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        foreach (var resort in resorts)
        {
            var points = JsonSerializer.Deserialize<Coordinate[]>(resort.Coordinates, options);
            if (points == null)
            {
                continue;
            }
            var maxNorth = points.Max(p => p.Lat);
            var maxEast = points.Max(p => p.Lng);
            var minSouth = points.Min(p => p.Lat);
            var minWest = points.Min(p => p.Lng);
            resortDtos.Add(new ResortDto
            {
                Id = resort.Id,
                Name = resort.Name,
                NorthEast = new Coordinate { Lat = maxNorth, Lng = maxEast },
                SouthWest = new Coordinate { Lat = minSouth, Lng = minWest }
            });
        }
        
        return Ok(resortDtos);
    }
}