using PlaceSaver.Dto;
using PlaceSaver.Dtos;

namespace PlaceSaver.Services.Impl;

public class ExternalApiService
{
    private readonly HttpClient _httpClient;

    public ExternalApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GooglePlacesResponse?> getPreviewPlacesAsync(PlaceSearchParameters parameters)
    {
        
        
        string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=52.2297,21.0122&radius=10000&type=tourist_attraction&key=";

       return await _httpClient.GetFromJsonAsync <GooglePlacesResponse> (url);
       

    }
  
    
    
    
    
    
    
    //https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=52.2297,21.0122&radius=10000&type=tourist_attraction&key=AIzaSyDTq2wi-ghmCforbIy5lo6RXdA5mrtuRV0&keyword=museum&opennow=true
}