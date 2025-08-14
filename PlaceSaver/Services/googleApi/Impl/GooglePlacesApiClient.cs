using PlaceSaver.Dto;
using PlaceSaver.Exceptions;

namespace PlaceSaver.Services.Impl;

public class GooglePlacesApiClient : IGooglePlacesApiClient
{
    
    private HttpClient _httpClient;

    public GooglePlacesApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
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
}