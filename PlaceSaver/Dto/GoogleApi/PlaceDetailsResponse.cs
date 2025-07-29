using System.Text.Json.Serialization;

namespace PlaceSaver.Dto;

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
}