using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProjectY.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ProjectY.Logic.Interfaces;
using ProjectY.Logic.Services;
using Swashbuckle.AspNetCore.SwaggerUI;

using ProjectY.Web.Api.Extensions;

namespace ProjectY.Web.Api
{
    /// <summary>
    /// Класс для конфигурации веб приложения
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _hostEnvironment;

        /// <summary>
        /// Конструктор класса для конфигурации веб приложения
        /// </summary>
        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            _configuration = configuration;
            _hostEnvironment = hostEnvironment;
        }

        /// <summary>
        /// Сидирование DI
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(options =>
            {
                options
                    .UseNpgsql(_configuration.GetConnectionString("Postgres"))
                    .EnableSensitiveDataLogging()
                    .LogTo(Console.WriteLine);
            });

            services.AddAutoMapper();
            services.AddScoped<ITestService, TestService>();

            if (!_hostEnvironment.IsProduction())
            {
                services.AddSwagger();
            }
        }

        /// <summary>
        /// Настройка дата пайплайна
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project Y API V1");
                c.RoutePrefix = string.Empty;
                c.DocExpansion(DocExpansion.None);
            });
            app.UseRouting().UseEndpoints(configure => configure.MapControllers());
        }
    }
}
