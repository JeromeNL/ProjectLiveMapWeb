namespace BusinessLogic;

public static class ValidationLogic
{
    private static readonly List<(double Latitude, double Longitude)> Points =
    [
        (51.653202521428078, 5.0413749255922244),
        (51.653721716281296, 5.0550985543836768),
        (51.64661222380488, 5.0575641086431933),
        (51.646425817616468, 5.0443668045587984),
        (51.649581304758911, 5.0386373727005704)
    ];
    
    public static bool IsPointInsidePolygon(double latitude, double longitude)
    {
        var numIntersections = 0;
        const double tolerance = 1e-6;
        for (var i = 0; i < Points.Count; i++)
        {
            var x1 = Points[i].Item1;
            var y1 = Points[i].Item2;
            var x2 = Points[(i + 1) % Points.Count].Item1;
            var y2 = Points[(i + 1) % Points.Count].Item2;

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