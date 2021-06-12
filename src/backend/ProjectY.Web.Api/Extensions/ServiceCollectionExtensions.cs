using System;
using System.IO;
using System.Linq;
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
                Enumerable.Empty<Type>()
                    .Concat(typeof(EmptyProfile)
                        .Assembly.GetTypes()
                        .Where(x => x.BaseType == typeof(Profile)))
                    .Concat(typeof(Application.Logic.Profiles.EmptyProfile)
                        .Assembly.GetTypes()
                        .Where(x => x.BaseType == typeof(Profile)))
                    .ToList()
                    .ForEach(config.AddProfile);
            }).CreateMapper());

            return services;
        }
    }
}
