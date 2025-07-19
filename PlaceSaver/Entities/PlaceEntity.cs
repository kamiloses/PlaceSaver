
namespace PlaceSaver.Entities;

public class PlaceEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Vicinity { get; set; }
    public string Photo { get; set; }
    public DateTime? EstimatedStartDate { get; set; }
    public DateTime? EstimatedEndDate { get; set; }
    public int PlaceAddressId { get; set; }
    public PlaceAddressEntity PlaceAddress { get; set; } 
    public string GoogleId { get; set; }
}