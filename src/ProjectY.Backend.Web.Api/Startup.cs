using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectY.Backend.Application.ExceptionHandling;
using ProjectY.Backend.Data;
using ProjectY.Backend.Data.Extensions;
using ProjectY.Backend.Web.Api.Extensions;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ProjectY.Backend.Web.Api
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

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                builder.WithOrigins("http://localhost:3000", "https://localhost:3001")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials());
            });

            services.AddRepositoryContext(opt =>
            {
                opt.ConnectionString = _configuration.GetConnectionString("Postgres");
            });
            services.AddAutoMapper();
            services.AddServices();

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
            app.UseMiddleware<ExceptionHandler>();

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

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseEndpoints(configure => configure.MapControllers());
        }
    }
}
