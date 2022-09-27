using System.Net.Http;
using System.Net.Http.Headers;

namespace Web.Helpers
{
    public class ActionHelpers
    {        
        HttpClient _httpClient;

        public ActionHelpers( HttpClient httpClient)
        {            
            _httpClient = httpClient;
        }   

        public async Task<T> SendAsyncRequets<T>(string Method, string Uri, object Content = null )
        {
            var _httpRequest = new HttpRequestMessage();
            _httpRequest.Method = new HttpMethod(Method);
            _httpRequest.RequestUri = new Uri(Uri);
            _httpRequest.Content = JsonContent.Create(Content);
            var response = await _httpClient.SendAsync(_httpRequest);
            return await response.Content.ReadFromJsonAsync<T>();            
        }

        public async Task<T>SendAsyncSecureRequets<T>(string Method, string Uri, string token, object Content = null)
        {
            var _httpRequest = new HttpRequestMessage();
            _httpRequest.Method = new HttpMethod(Method);
            _httpRequest.RequestUri = new Uri(Uri);
            _httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            _httpRequest.Content = JsonContent.Create(Content);

            var response = await _httpClient.SendAsync(_httpRequest);
            return await response.Content.ReadFromJsonAsync<T>();            
        }

        public async Task<T> SendAsyncHeadersRequets<T>(string Method, string Uri, object Content = null)
        {
            var _httpRequest = new HttpRequestMessage();
            _httpRequest.Method = new HttpMethod(Method);
            _httpRequest.RequestUri = new Uri(Uri);
            _httpRequest.Headers.Add("X-RapidAPI-Key", "e3fbe4106cmshcdcc0d8ede722b8p16eea9jsne63fd9bdfb4e");
            _httpRequest.Headers.Add("X-RapidAPI-Host", "movie-details1.p.rapidapi.com");                    
            var response = await _httpClient.SendAsync(_httpRequest);
            return await response.Content.ReadFromJsonAsync<T>();
        }

    }
}
