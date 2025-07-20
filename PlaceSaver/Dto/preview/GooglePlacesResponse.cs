using System.Text.Json.Serialization;

namespace PlaceSaver.Dtos;

public class GooglePlacesResponse
{
    
    public List<PlacePreviewResponse> Results { get; set; }
    
    
    
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("error_message")]
    public string ErrorMessage { get; set; }
    
}