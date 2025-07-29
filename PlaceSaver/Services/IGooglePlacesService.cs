using PlaceSaver.Dto;

namespace PlaceSaver.Services;

public interface IGooglePlacesService
{

    Task<GooglePlacesResponse?> GetPlacesAsync(PlaceSearchParameters parameters);
    Task<GooglePlacesResponse?> FetchAndHandlePlacesAsync(string url);


}