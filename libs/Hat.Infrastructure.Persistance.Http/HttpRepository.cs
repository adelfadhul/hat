using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http.Json;

namespace Hat.Infrastructure.Persistance.Http
{
    public abstract class HttpRepository<T>
    {
        protected readonly HttpClient _http;
        protected readonly ILogger<HttpRepository<T>> _logger;
        public HttpRepository(HttpClient http, ILogger<HttpRepository<T>> logger)
        {
            _http = http;
            _logger = logger;
        }

        protected async Task<List<T>> GetList(string url)
        {
            try
            {
                var response = await _http.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var obj = await response.Content.ReadFromJsonAsync<List<T>>();
                    _logger.LogInformation("Received List Of Objects: {@Objects}", obj);
                    return obj;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _logger.LogWarning("Requested resource not found (404) at URL: {Url}", url);
                    return null;
                }
                else
                {
                    _logger.LogError("Failed to get list. Status code: {StatusCode}", response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while fetching list from URL: {Url}", url);
                return null;
            }
        }

        protected async Task<T> GetSingle(string url)
        {
            try
            {
                var response = await _http.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var obj = await response.Content.ReadFromJsonAsync<T>();
                    _logger.LogInformation("Received object: {@Object}", obj);
                    return obj;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _logger.LogWarning("Requested item not found (404) at URL: {Url}", url);
                    return default;
                }
                else
                {
                    _logger.LogError("Failed to get item. Status code: {StatusCode}", response.StatusCode);
                    return default;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while fetching item from URL: {Url}", url);
                return default;
            }
        }
    }
}
