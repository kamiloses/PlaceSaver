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

    public string? PhotoUrl
    {
        get
        {
            if (Photos != null && Photos.Count > 0)
            {
                string apiKey = File.ReadAllText("key.txt").Trim(); 
                return $"https://maps.googleapis.com/maps/api/place/photo?maxwidth=800&photo_reference={Photos[0].PhotoReference}&key={apiKey}";
            }

            return null;
        }
    }

    public class Photo
    {
        [JsonPropertyName("photo_reference")]
        public string PhotoReference { get; set; }
    }
}