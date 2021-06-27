using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectY.Frontend.Brokers.Api
{
    /// <summary>
    /// Базовый класс для брокеров апи
    /// </summary>
    public abstract class ApiBrokerBase
    {
        private readonly HttpClient _apiClient;

        /// <summary>
        /// Базовый класс для брокеров апи
        /// </summary>
        protected ApiBrokerBase(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// Отправить GET-запрос
        /// </summary>
        protected async Task<T> GetAsync<T>(string relativeUrl)
        {
            var response = await _apiClient.GetAsync(relativeUrl);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseJson);
        }

        /// <summary>
        /// Отправить POST-запрос
        /// </summary>
        protected async Task<TResponse> PostAsync<TRequest, TResponse>(string relativeUrl, TRequest content)
        {
            var response = await _apiClient.PostAsJsonAsync(relativeUrl, content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseJson);
        }

        /// <summary>
        /// Отправить PUT-запрос
        /// </summary>
        protected async Task<TResponse> PutAsync<TRequest, TResponse>(string relativeUrl, TRequest content)
        {
            var response = await _apiClient.PutAsJsonAsync(relativeUrl, content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseJson);
        }

        /// <summary>
        /// Отправить DELETE-запрос
        /// </summary>
        protected async Task DeleteAsync(string relativeUrl)
        {
            var response = await _apiClient.DeleteAsync(relativeUrl);
            response.EnsureSuccessStatusCode();
        }
    }
}
