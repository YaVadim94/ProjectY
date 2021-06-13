using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProjectY.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ProjectY.Data.Extensions;
using ProjectY.Logic.Interfaces;
using ProjectY.Logic.Services;
using Serilog;
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

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration, sectionName: "Serilog")
                .CreateLogger();
        }

        /// <summary>
        /// Сидирование DI
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRepositoryContext(opt =>
            {
                opt.ConnectionString = _configuration.GetConnectionString("Postgres");
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
            if (!env.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project Y API V1");
                    c.RoutePrefix = string.Empty;
                    c.DocExpansion(DocExpansion.None);
                });
            }

            app.UseApplyMigration<DataContext>();

            app.UseRouting().UseEndpoints(configure => configure.MapControllers());
        }
    }
}
