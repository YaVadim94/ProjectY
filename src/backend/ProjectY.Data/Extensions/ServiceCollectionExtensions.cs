using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectY.Data.Options;

namespace ProjectY.Data.Extensions
{
    /// <summary>
    /// Класс с методами регистрации репозиториев и контекста БД.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Зарегистрировать контекст БД.
        /// </summary>
        /// <returns>Коллекция сервисов</returns>
        public static IServiceCollection AddRepositoryContext(this IServiceCollection services,
            Action<ProjectYDbOptions> configure)
        {
            var options = new ProjectYDbOptions();
            configure?.Invoke(options);

            services.AddDbContext<DataContext>(opt =>
            {
                opt
                    .UseNpgsql(options.ConnectionString)
                    .EnableSensitiveDataLogging()
                    .LogTo(Console.WriteLine);
            });
            return services;
        }

        /// <summary>
        /// Использовать применение автомиграций.
        /// </summary>
        public static void UseApplyMigration<TContext>(this IApplicationBuilder builder)
            where TContext : DbContext
        {
            builder
                .ApplicationServices
                .ApplyMigration<TContext>();
        }

        /// <summary>
        /// Применить миграции.
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="provider"></param>
        public static void ApplyMigration<TContext>(this IServiceProvider provider)
            where TContext : DbContext
        {
            using var scope = provider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<TContext>();

            context.Database.Migrate();
        }
    }
}
