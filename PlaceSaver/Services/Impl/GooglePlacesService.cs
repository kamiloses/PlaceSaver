using System.Globalization;
using PlaceSaver.Dto;
using PlaceSaver.Exceptions;

namespace PlaceSaver.Services.Impl;

public class GooglePlacesService : IGooglePlacesService
{
    private readonly HttpClient _httpClient;
    private static readonly string Url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";

    public GooglePlacesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GooglePlacesResponse?> GetPlacesAsync(PlaceSearchParameters parameters)
    {
        string url = BuildGooglePlacesUrl(Url, parameters);
        var response = await FetchAndHandlePlacesAsync(url);

        if (response?.Results != null)
        {
            foreach (var place in response.Results)
            {
                if (place.Photos.Count > 0)
                {
                    string photoReference = place.Photos[0].PhotoReference;
                    place.PhotoUrl = BuildPhotoUrl(photoReference);
                }
            }
        }

        return response;
    }


    private string BuildPhotoUrl(string photoReference)
    {
        string apiKey = File.ReadAllText("key.txt").Trim();

        return
            $"https://maps.googleapis.com/maps/api/place/photo?maxwidth=800&photo_reference={photoReference}&key={apiKey}";
    }


    public async Task<GooglePlacesResponse?> FetchAndHandlePlacesAsync(string url)
    {
        HttpResponseMessage initialConnectionResponse;

        try
        {
            initialConnectionResponse = await _httpClient.GetAsync(url);

            if (!initialConnectionResponse.IsSuccessStatusCode)
            {
                throw new GoogleApiException("The status code is not success. Reason: " + initialConnectionResponse.ReasonPhrase);
            }
        }
        catch (Exception ex) when (ex is not GoogleApiException)
        {
            throw new GoogleApiException("There was a problem connecting to the external API.", ex);
        }


        try
        {
            var googlePlacesData = await initialConnectionResponse.Content.ReadFromJsonAsync<GooglePlacesResponse>();
            if (googlePlacesData == null || googlePlacesData.Status == "INVALID_REQUEST")
            {
                throw new GoogleApiInvalidEndpointException("Given endpoint is invalid");
            }

            if (googlePlacesData.Status == "REQUEST_DENIED")
            {
                throw new GoogleApiKeyInvalidOrExpiredException("Given token is denied");
            }

            if (googlePlacesData.Status == "ZERO_RESULTS")
            {
                return new GooglePlacesResponse();
            }

            return googlePlacesData;
        }
        catch (Exception ex) when
            (ex is not (GoogleApiInvalidEndpointException or GoogleApiKeyInvalidOrExpiredException))
        {
            throw new GoogleApiFetchingException("There was some problem with fetching data from google api", ex);
        }
    }



    private string BuildGooglePlacesUrl(string baseUrl, PlaceSearchParameters parameters)
    {
        string apiKey = File.ReadAllText("key.txt").Trim();


        string location =
            $"{parameters.Latitude.ToString(CultureInfo.InvariantCulture)},{parameters.Longitude.ToString(CultureInfo.InvariantCulture)}";

        Console.BackgroundColor = ConsoleColor.Yellow;

        string url = $"{baseUrl}?location={location}&radius={parameters.Radius}&key={apiKey}";

        if (!string.IsNullOrWhiteSpace(parameters.Keyword))
        {
            url += $"&keyword={parameters.Keyword}";
        }

        if (!string.IsNullOrWhiteSpace(parameters.Type) && string.IsNullOrWhiteSpace(parameters.Keyword))
        {
            url += $"&type={parameters.Type}";
        }

        if (parameters.OpenNow.HasValue)
        {
            url += $"&opennow={parameters.OpenNow.Value.ToString().ToLower()}";
        }

        Console.WriteLine("url " + url);

        return url;
    }
}