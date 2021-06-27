using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using ProjectY.Frontend.Brokers.Api;
using ProjectY.Frontend.Services.TestService;

namespace ProjectY.Frontend.Extensions
{
    /// <summary>
    /// Расширения для <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавить все необходимые сервисы приложения
        /// </summary>
        public static IServiceCollection AddServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<ITestService, TestService>();

            return serviceDescriptors;
        }

        /// <summary>
        /// Настроить брокера апи
        /// </summary>
        public static IServiceCollection ConfigureBrokers(this IServiceCollection serviceDescriptors, string baseAddress)
        {
            serviceDescriptors.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            serviceDescriptors.AddScoped<IApiBroker, ApiBroker>();

            return serviceDescriptors;
        }
    }
}
