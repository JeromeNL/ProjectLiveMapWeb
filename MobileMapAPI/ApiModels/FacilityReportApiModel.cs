namespace MobileMapAPI.ApiModels;

public class FacilityReportApiModel
{
    public int FacilityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string IconUrl { get; set; }
}


