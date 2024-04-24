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
        var numIntersections = 0;
        const double tolerance = 1e-6;
        for (var i = 0; i < parsedCoordinates.Count; i++)
        {
            var x1 = parsedCoordinates[i].Lng;
            var y1 = parsedCoordinates[i].Lat;
            var x2 = parsedCoordinates[(i + 1) % parsedCoordinates.Count].Lng;
            var y2 = parsedCoordinates[(i + 1) % parsedCoordinates.Count].Lat;

            if (Math.Abs(latitude - x1) < tolerance && Math.Abs(longitude - y1) < tolerance)
                return true;

            if (((y1 <= longitude && longitude < y2) || (y2 <= longitude && longitude < y1)) &&
                (latitude < (x2 - x1) * (longitude - y1) / (y2 - y1) + x1))
            {
                numIntersections++;
            }
        }

        return numIntersections % 2 == 1;
    } 
}