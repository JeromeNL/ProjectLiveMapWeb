using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Interfaces;
using Newtonsoft.Json;

namespace DataAccess.Models;

public class HolidayResort : ISoftDelete
{
    public DateTimeOffset? DeletedAt { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }


    [Required(ErrorMessage = "Het naam veld is verplicht")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Een selectie op de map is verplicht")]
    public string Coordinates { get; set; }
    
    public Coordinate GetCoordinatesOfCenterPoint()
    {
        var parsedCoordinates = JsonConvert.DeserializeObject<List<Coordinate>>(Coordinates);
        var vertexCount = parsedCoordinates.Count;

        double sumX = 0;
        double sumY = 0;
        double area = 0;
        
        for (var i = 0; i < vertexCount; i++)
        {
            var currentVertex = parsedCoordinates[i];
            var nextVertex = parsedCoordinates[(i + 1) % vertexCount];

            var crossProduct = currentVertex.Lng * nextVertex.Lat - nextVertex.Lng * currentVertex.Lat;
            sumX += (currentVertex.Lng + nextVertex.Lng) * crossProduct;
            sumY += (currentVertex.Lat + nextVertex.Lat) * crossProduct;
            area += crossProduct;
        }

        area /= 2f;

        return new Coordinate
        {
            Lng = sumX / (6f * area),
            Lat = sumY / (6f * area)
        };
    }

    public bool IsPointInside(double latitude, double longitude)
    {
        var parsedCoordinates = JsonConvert.DeserializeObject<List<Coordinate>>(Coordinates);
        var vertexCount = parsedCoordinates.Count;
        var inside = false;

        // Ray casting algorithm
        for (int i = 0, j = vertexCount - 1; i < vertexCount; j = i++)
        {
            if (((parsedCoordinates[i].Lat > latitude) != (parsedCoordinates[j].Lat > latitude)) &&
                (longitude < (parsedCoordinates[j].Lng - parsedCoordinates[i].Lng) * (latitude - parsedCoordinates[i].Lat) /
                    (parsedCoordinates[j].Lat - parsedCoordinates[i].Lat) + parsedCoordinates[i].Lng))
            {
                inside = !inside;
            }
        }

        return inside;
    } 
}