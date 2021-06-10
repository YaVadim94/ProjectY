using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjectY.Web.Api.Profiles;

namespace ProjectY.Web.Api.Extensions
{
    /// <summary>
    /// Класс с методами расширения колекции сервисов.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Зарегистрировать Swagger.
        /// </summary>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });

            return services;
        }

        /// <summary>
        /// Зарегистировать AutoMapper.
        /// </summary>
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddScoped(provider => new MapperConfiguration(config =>
            {
                config.AddProfile(new HomeProfile());
            }).CreateMapper());

            return services;
        }
    }
}
