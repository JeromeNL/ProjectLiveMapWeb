namespace BusinessLogic;

public static class ValidationLogic
{
    private static readonly List<(double Latitude, double Longitude)> points =
        new List<(double Latitude, double Longitude)>()
        {
            (51.653202521428078, 5.0413749255922244),
            (51.653721716281296, 5.0550985543836768),
            (51.64661222380488, 5.0575641086431933),
            (51.646425817616468, 5.0443668045587984),
            (51.649581304758911, 5.0386373727005704),
        };
    
    public static bool IsPointInsidePolygon(this string coords, double latitude, double longitude)
    {
        int numIntersections = 0;
        double tolerance = 1e-6;
        for (int i = 0; i < points.Count; i++)
        {
            double x1 = points[i].Item1;
            double y1 = points[i].Item2;
            double x2 = points[(i + 1) % points.Count].Item1;
            double y2 = points[(i + 1) % points.Count].Item2;

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