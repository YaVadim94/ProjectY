using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProjectY.Frontend.Application.Brokers.Api
{
    public abstract class ApiBrokerBase
    {
        private readonly HttpClient _apiClient;

        protected ApiBrokerBase(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        protected async Task<T> GetAsync<T>(string relativeUrl)
        {
            var response = await _apiClient.GetAsync(relativeUrl);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseJson);
        }


        protected async Task<TResponse> PostAsync<TRequest, TResponse>(string relativeUrl, TRequest content)
        {
            var response = await _apiClient.PostAsJsonAsync(relativeUrl, content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseJson);
        }

        protected async Task<TResponse> PutAsync<TRequest, TResponse>(string relativeUrl, TRequest content)
        {
            var response = await _apiClient.PutAsJsonAsync(relativeUrl, content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseJson);
        }

        protected async Task DeleteAsync(string relativeUrl)
        {
            var response = await _apiClient.DeleteAsync(relativeUrl);
            response.EnsureSuccessStatusCode();
        }
    }
}
