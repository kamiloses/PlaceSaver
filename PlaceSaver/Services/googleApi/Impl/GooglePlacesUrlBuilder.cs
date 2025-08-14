using System.Globalization;
using PlaceSaver.Dto;

namespace PlaceSaver.Services.Impl;

public class GooglePlacesUrlBuilder : IGooglePlacesUrlBuilder
{
    
    public string BuildPhotoUrl(string photoReference)
    {
        string apiKey = File.ReadAllText("key.txt").Trim();

        return
            $"https://maps.googleapis.com/maps/api/place/photo?maxwidth=800&photo_reference={photoReference}&key={apiKey}";
    }
    
    public string BuildGooglePlacesUrl(string baseUrl, PlaceSearchParameters parameters)
    {
        string apiKey = File.ReadAllText("key.txt").Trim();


        string location =
            $"{parameters.Latitude.ToString(CultureInfo.InvariantCulture)},{parameters.Longitude.ToString(CultureInfo.InvariantCulture)}";


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