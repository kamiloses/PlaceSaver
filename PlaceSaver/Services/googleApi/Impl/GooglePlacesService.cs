using PlaceSaver.Dto;

namespace PlaceSaver.Services.Impl;

public class GooglePlacesService : IGooglePlacesService
{
    
    //TODO WSZEDZIE DODAĆ INTERFEJSY WSTRZYKIWANIE ZAMIAST IMPLEMENTACJI
    private readonly GooglePlacesApiClient _googlePlacesApiClient;
    private readonly GooglePlacesUrlBuilder _googlePlacesUrlBuilder;
    private static readonly string Url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";

    public GooglePlacesService(GooglePlacesApiClient googlePlacesApiClient, GooglePlacesUrlBuilder googlePlacesUrlBuilder)
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
                if (place.Photos.Count > 0)
                {
                    string photoReference = place.Photos[0].PhotoReference;
                    place.PhotoUrl = _googlePlacesUrlBuilder.BuildPhotoUrl(photoReference);
                }
            }
            
        }
      

        return response;
    }
}