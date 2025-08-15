using PlaceSaver.Dto;

namespace PlaceSaver.Services.GoogleApi.Impl;

public class GooglePlacesService : IGooglePlacesService
{
    
    
    
    private readonly IGooglePlacesApiClient _googlePlacesApiClient;
    private readonly IGooglePlacesUrlBuilder _googlePlacesUrlBuilder;
    private static readonly string Url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";

    public GooglePlacesService(IGooglePlacesApiClient googlePlacesApiClient, IGooglePlacesUrlBuilder googlePlacesUrlBuilder)
    {
        _googlePlacesApiClient = googlePlacesApiClient;
        _googlePlacesUrlBuilder = googlePlacesUrlBuilder;
    }

    public async Task<GooglePlacesResponse?> GetPlacesAsync(PlaceSearchParameters parameters)
    {
        string url = _googlePlacesUrlBuilder.BuildGooglePlacesUrl(Url, parameters);
        var response = await _googlePlacesApiClient.FetchAndHandlePlacesAsync(url);

        if (response?.Results != null)
        {
            foreach (var place in response.Results)
            {
                if (place.Photos?.Count > 0)
                {
                    string photoReference = place.Photos[0].PhotoReference;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(photoReference);
                    
                    place.PhotoUrl = _googlePlacesUrlBuilder.BuildPhotoUrl(photoReference);
                }
            }
            
        }
      

        return response;
    }
}