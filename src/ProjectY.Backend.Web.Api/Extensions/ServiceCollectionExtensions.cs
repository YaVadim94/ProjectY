using System;
using System.IO;
using System.Reflection;
using AutoMapper.EquivalencyExpression;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectY.Backend.Web.Api.Extensions
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
            var assemblies = new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "ProjectY.Backend.Application.Logic.dll")),
            };

            services.AddAutoMapper(cfg => cfg.AddCollectionMappers(), assemblies);

            return services;
        }

        /// <summary>
        /// Зарегистрировать медиатр.
        /// </summary>
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            return services.AddMediatR(
                Assembly.LoadFrom(
                    Path.Combine(AppContext.BaseDirectory, "ProjectY.Backend.Application.Logic.dll")));
        }

        /// <summary>
        /// Зарегистрировать FluentValidation.
        /// </summary>
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            return services.AddFluentValidation(conf =>
            {
                var assemblies = new[]
                {
                    Assembly.GetExecutingAssembly(),
                    Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "ProjectY.Backend.Application.Logic.dll"))
                };

                conf.RegisterValidatorsFromAssemblies(assemblies);
            });
        }
    }
}
