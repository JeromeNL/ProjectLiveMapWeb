using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataAccess.Validation;

public class PolygonValidation : ValidationAttribute
{
    private readonly List<(double Latitude, double Longitude)> _polygonVertices =
        new List<(double Latitude, double Longitude)>()
        {
            (51.3422208920495, 5.241121225493207),
            (51.34488819214301, 5.25017375204897),
            (51.3414702670499, 5.257591469196808),
            (51.33793144075602, 5.249741910731706)
        };

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            var latitude = (double)value;
            var longitude = (double)validationContext.ObjectType.GetProperty("Longitude").GetValue(validationContext.ObjectInstance, null);

            // Check if the point is inside the polygon
            if (!IsPointInsidePolygon(latitude, longitude, _polygonVertices))
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }

    private bool IsPointInsidePolygon(double latitude, double longitude, List<(double Latitude, double Longitude)> points)
    {
        // Implementation of point-in-polygon algorithm (e.g., Ray Casting or Winding Number)
        // Your implementation goes here
        // You may need to use a library or implement the algorithm yourself
        
        int numIntersections = 0;
        double tolerance = 1e-6;
        for (int i = 0; i < points.Count; i++)
        {
            double x1 = points[i].Item1;
            double y1 = points[i].Item2;
            double x2 = points[(i + 1) % points.Count].Item1;
            double y2 = points[(i + 1) % points.Count].Item2;

            // Check if the point is very close to the current vertex
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