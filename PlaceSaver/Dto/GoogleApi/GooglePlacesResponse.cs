using System.Text.Json.Serialization;

namespace PlaceSaver.Dto;

public class GooglePlacesResponse
{
    
    public List<PlaceDetailsResponse>? Results { get; set; }
    
    
    
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }
    
}