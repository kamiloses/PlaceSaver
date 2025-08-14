using PlaceSaver.Exceptions;

namespace PlaceSaver.Services.Impl;

public class HttpClientWrapper : IHttpClientWrapper
{
    private readonly HttpClient _httpClient;

    public HttpClientWrapper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> GetAsync(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new GoogleApiException("The status code is not success. Reason: "+ response.ReasonPhrase);
            }
            
            return response;
        }
        catch (Exception ex ) when (!(ex is GoogleApiException))
        {
            
            
            throw new GoogleApiException("There was a problem connecting to the external API.", ex);
        }
        
        
    
    }

    public Task<T?> ReadFromJsonAsync<T>(string url)
    {
        throw new NotImplementedException();
    }
}