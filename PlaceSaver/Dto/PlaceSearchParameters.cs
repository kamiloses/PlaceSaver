namespace PlaceSaver.Dto;

public class PlaceSearchParameters
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Radius { get; set; } = 1000;
    public string? Type { get; set; }
    public string? Keyword { get; set; }
    public bool? OpenNow { get; set; }


    public override string ToString()
    {
        return
            $"{nameof(Latitude)}: {Latitude}, {nameof(Longitude)}: {Longitude}, {nameof(Radius)}: {Radius}, {nameof(Type)}: {Type}, {nameof(Keyword)}: {Keyword}, {nameof(OpenNow)}: {OpenNow}";
    }
}
