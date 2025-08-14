using PlaceSaver.Dto;

namespace PlaceSaver.Services;

public interface IGooglePlacesUrlBuilder
{
    string BuildPhotoUrl(string photoReference);
    string BuildGooglePlacesUrl(string baseUrl, PlaceSearchParameters parameters);
}