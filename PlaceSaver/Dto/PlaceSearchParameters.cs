using System.ComponentModel.DataAnnotations;

namespace PlaceSaver.Dto;
public class PlaceSearchParameters
{
    [Range(-90, 90)]
    public double Latitude { get; set; }

    [Range(-180, 180)]
    public double Longitude { get; set; }

    [Range(1, 50000)]
    public int Radius { get; set; }
    public string? Type { get; set; }
    public string? Keyword { get; set; }
    public bool? OpenNow { get; set; }
    
}
