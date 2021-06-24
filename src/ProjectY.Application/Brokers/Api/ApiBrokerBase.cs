using System.Net.Http;

namespace ProjectY.Frontend.Application.Brokers.Api
{
    public abstract class ApiBrokerBase
    {
        private readonly HttpClient _apiClient;

        protected ApiBrokerBase(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        //protected async Task<T> GetAsync<T>(string relativeUrl)
        //{
        //    var response = await _apiClient.GetAsync(relativeUrl);
        //    response.EnsureSuccessStatusCode();

        //    var responseJson = response.Content.ReadAsStringAsync();
        //    return JsonConvert;
        //}


        //protected async Task<T> PostAsync<T>(string relativeUrl, T content) =>
        //    await _apiClient.PostContentAsync<T>(relativeUrl, content);

        //protected async Task<T> PutAsync<T>(string relativeUrl, T content) =>
        //    await _apiClient.PutContentAsync<T>(relativeUrl, content);

        //protected async Task<T> DeleteAsync<T>(string relativeUrl) =>
        //    await _apiClient.GetContentAsync<T>(relativeUrl);
    }
}
