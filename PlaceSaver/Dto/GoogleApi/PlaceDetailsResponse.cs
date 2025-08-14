using System.Text.Json.Serialization;

namespace PlaceSaver.Dto;

#pragma warning disable CS8618
public class PlaceDetailsResponse
{
    [JsonPropertyName("place_id")]
    public string PlaceId { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("vicinity")]
    public string Vicinity { get; set; } 

    [JsonPropertyName("types")]
    public IEnumerable<string> Types { get; set; }

    [JsonPropertyName("photos")]
    public List<Photo> Photos { get; set; }

    [JsonPropertyName("rating")]
    public double Rating { get; set; }

    [JsonPropertyName("user_ratings_total")]
    public int NumberOfRatings { get; set; }

    public string? PhotoUrl { get; set; }
    

    public class Photo
    {
        [JsonPropertyName("photo_reference")]
        public string PhotoReference { get; set; }
    }

    public override string ToString()
    {
        return
            $"{nameof(PlaceId)}: {PlaceId}, {nameof(Name)}: {Name}, {nameof(Vicinity)}: {Vicinity}, {nameof(Types)}: {Types}, {nameof(Photos)}: {Photos}, {nameof(Rating)}: {Rating}, {nameof(NumberOfRatings)}: {NumberOfRatings}, {nameof(PhotoUrl)}: {PhotoUrl}";
    }
}