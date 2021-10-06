﻿using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectY.Frontend.Application.Brokers.Api
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
        /// Относительный урл контроллера бекенда
        /// </summary>
        protected abstract string ControllerUrl { get; }

        /// <summary>
        /// Отправить GET-запрос
        /// </summary>
        protected async Task<T> GetAsync<T>(string methodUrl, string oDataString = null)
        {
            var oDataRelatedUrl = string.Concat(GetRelativeUrl(methodUrl), oDataString ?? string.Empty);

            var response = await _apiClient.GetAsync(oDataRelatedUrl);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseJson);
        }

        /// <summary>
        /// Отправить POST-запрос
        /// </summary>
        protected async Task<TResponse> PostAsync<TRequest, TResponse>(string methodUrl, TRequest content)
        {
            var response = await _apiClient.PostAsJsonAsync(GetRelativeUrl(methodUrl), content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseJson);
        }

        /// <summary>
        /// Отправить PUT-запрос
        /// </summary>
        protected async Task<TResponse> PutAsync<TRequest, TResponse>(string methodUrl, TRequest content)
        {
            var response = await _apiClient.PutAsJsonAsync(GetRelativeUrl(methodUrl), content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseJson);
        }

        /// <summary>
        /// Отправить DELETE-запрос
        /// </summary>
        protected async Task DeleteAsync(string methodUrl)
        {
            var response = await _apiClient.DeleteAsync(GetRelativeUrl(methodUrl));
            response.EnsureSuccessStatusCode();
        }

        private string GetRelativeUrl(string methodUrl)
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
            var controllerUrl = GetType().GetProperty("ControllerUrl", flags).GetValue(this) as string;
            return $"{controllerUrl}/{methodUrl}";
        }
    }
}
