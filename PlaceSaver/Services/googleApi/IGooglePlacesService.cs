using PlaceSaver.Dto;

namespace PlaceSaver.Services;

public interface IGooglePlacesService
{

    Task<GooglePlacesResponse?> GetPlacesAsync(PlaceSearchParameters parameters);


}