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
        if (parsedCoordinates == null) return new Coordinate {Lat = 0, Lng = 0};
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
        var polygon = JsonConvert.DeserializeObject<List<Coordinate>>(Coordinates);
        if (polygon == null) return false;
        
        var count = 0;
        for (int i = 0, j = polygon.Count - 1; i < polygon.Count; j = i++)
        {
            if (((polygon[i].Lat <= latitude && latitude < polygon[j].Lat) ||
                 (polygon[j].Lat <= latitude && latitude < polygon[i].Lat)) &&
                (longitude < (polygon[j].Lng - polygon[i].Lng) * (latitude - polygon[i].Lat) /
                    (polygon[j].Lat - polygon[i].Lat) +
                    polygon[i].Lng))
            {
                count++;
            }
        }

        return count % 2 == 1;
    } 
}