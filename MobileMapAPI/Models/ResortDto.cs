namespace MobileMapAPI.Models;

public class ResortDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Coordinate NorthEast { get; set; }
    public Coordinate SouthWest { get; set; }
}