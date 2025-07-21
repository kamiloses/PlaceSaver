using System.Globalization;
using PlaceSaver.Dto;
using PlaceSaver.Exceptions;

namespace PlaceSaver.Services.Impl;

public class ExternalApiService
{
    private readonly HttpClient _httpClient;
    private static readonly string Url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";

    public ExternalApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GooglePlacesResponse?> GetPreviewPlacesAsync(PlaceSearchParameters parameters)
    {
        string url = BuildGooglePlacesUrl(Url, parameters);

        return await FetchAndHandlePreviewPlacesAsync(url);

    }


    private async Task<GooglePlacesResponse?> FetchAndHandlePreviewPlacesAsync(string url)
    {
        var response = await _httpClient.GetFromJsonAsync<GooglePlacesResponse>(url);

        if (response == null || (response.Status != "OK" && response.Status != "ZERO_RESULTS"))
        {
            throw new ExternalApiException("No response from Google Places API");
        }

        return response;
    }


    private static string BuildGooglePlacesUrl(string baseUrl,PlaceSearchParameters parameters)
    {
        string apiKey = File.ReadAllText("key.txt").Trim();

        
        string location =
            $"{parameters.Latitude.ToString(CultureInfo.InvariantCulture)},{parameters.Longitude.ToString(CultureInfo.InvariantCulture)}";

        string url = $"{baseUrl}?location={location}&radius={parameters.Radius}&key={apiKey}";

        if (!string.IsNullOrWhiteSpace(parameters.Keyword))
        {
            parameters.Type = null;
            url += $"&keyword={parameters.Keyword}";
        }

        if (!string.IsNullOrWhiteSpace(parameters.Type))
        {
            url += $"&type={parameters.Type}";
        }

        if (parameters.OpenNow.HasValue)
        {
            url += $"&opennow={parameters.OpenNow.Value.ToString().ToLower()}";
        }

        return url;
    }
}