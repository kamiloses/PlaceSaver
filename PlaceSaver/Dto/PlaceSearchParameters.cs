namespace PlaceSaver.Dto;

public class PlaceSearchParameters
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Radius { get; set; } = 1000;
    public string? Type { get; set; }
    public string? Keyword { get; set; }
    public bool? OpenNow { get; set; }
    
    


    
}
