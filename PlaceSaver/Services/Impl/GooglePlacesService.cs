using System.Globalization;
using PlaceSaver.Dto;
using PlaceSaver.Exceptions;

namespace PlaceSaver.Services.Impl;

public class GooglePlacesService : IGooglePlacesService
{

    private readonly HttpClientWrapper _httpClient;
    private static readonly string Url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";

    public GooglePlacesService(HttpClientWrapper httpClient)
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
                if (place.Photos?.Count > 0)
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
        
        return $"https://maps.googleapis.com/maps/api/place/photo?maxwidth=800&photo_reference={photoReference}&key={apiKey}";
    }
    

    
    
    
    
    
    
    public async Task<GooglePlacesResponse?> FetchAndHandlePlacesAsync(string url)
    {
//"status": "REQUEST_DENIED" 200 status
// "status": "INVALID_REQUEST" 200 stasus
// "results": [], "status": "ZERO_RESULTS" 200 status
        try
        {
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        { throw new GoogleApiException($"There was a problem connecting to the external API. Reason: {response.ReasonPhrase}"); }
        
        
        
        return await response.Content.ReadFromJsonAsync<GooglePlacesResponse>();
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
        // Console.WriteLine(googlePlacesData);

        // if (googlePlacesData == null || (googlePlacesData.Status != "OK" && googlePlacesData.Status != "ZERO_RESULTS"))
        // {
        //     throw new GoogleApiException("No response from Google Places API");
        // }
        //
        
        
        
        
        

        // return googlePlacesData;
    }
//todo wyjątek rzucany jak credentials jwt nie podane

    private  string BuildGooglePlacesUrl(string baseUrl,PlaceSearchParameters parameters)
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

        if (!string.IsNullOrWhiteSpace(parameters.Type)&&string.IsNullOrWhiteSpace(parameters.Keyword))
        {
            url += $"&type={parameters.Type}";
        }

        if (parameters.OpenNow.HasValue)
        {
            url += $"&opennow={parameters.OpenNow.Value.ToString().ToLower()}";
        }
        Console.WriteLine("url "+ url);

        return url;
    }
}