
namespace PlaceSaver.Entities;

public class PlaceEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public Address Address { get; set; } 
    public VisitPlan VisitPlan { get; set; } //todo sprawdz czy pola w visitPlan moga byc bez "?" a tutaj dam "?"
    public string GoogleId { get; set; }
}