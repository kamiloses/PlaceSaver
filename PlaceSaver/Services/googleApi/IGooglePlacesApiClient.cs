using PlaceSaver.Dto;

namespace PlaceSaver.Services;

public interface IGooglePlacesApiClient
{
    public  Task<GooglePlacesResponse?> FetchAndHandlePlacesAsync(string url);

}