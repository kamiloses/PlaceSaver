namespace PlaceSaver.Services;

public interface IHttpClientWrapper
{


    Task<HttpResponseMessage> GetAsync(string url);
    Task<T?> ReadFromJsonAsync<T>(string url);
}