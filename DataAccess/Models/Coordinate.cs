namespace DataAccess.Models;

public class Coordinate
{
    public double Lat { get; set; }
    public double Lng { get; set; }
    
    public override string ToString()
    {
        return $"[{Lat.ToString(System.Globalization.CultureInfo.InvariantCulture)}, {Lng.ToString(System.Globalization.CultureInfo.InvariantCulture)}]";
    }
}