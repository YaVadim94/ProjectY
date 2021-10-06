using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using ProjectY.Frontend.Application.Brokers.Api;
using ProjectY.Frontend.Application.Brokers.Api.Interfaces;
using ProjectY.Frontend.Application.Services.FileService;
using ProjectY.Frontend.Application.Services.ShoesService;

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
        public static IServiceCollection AddCustomServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IShoesService, ShoesService>();
            serviceDescriptors.AddScoped<IFileService, FileService>();

            return serviceDescriptors;
        }

        /// <summary>
        /// Настроить брокера апи
        /// </summary>
        public static IServiceCollection ConfigureBrokers(this IServiceCollection serviceDescriptors, string baseAddress)
        {
            serviceDescriptors.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

            serviceDescriptors.AddScoped<IShoesApiBroker, ShoesApiBroker>();
            serviceDescriptors.AddScoped<IAttachmentApiBroker, AttachmentApiBroker>();

            return serviceDescriptors;
        }
    }
}
