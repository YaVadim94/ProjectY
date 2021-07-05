using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectY.Backend.Data;
using ProjectY.Backend.Data.Extensions;
using ProjectY.Backend.Web.Api.Extensions;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using ExceptionHandler = ProjectY.Backend.Web.Api.Middleware.ExceptionHandler;

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
            services
                .AddControllers()
                .AddOData(opt => opt.Filter().OrderBy().SkipToken().SetMaxTop(int.MaxValue))
                .AddNewtonsoftJson();


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


            if (!_hostEnvironment.IsProduction())
            {
                services.AddSwagger();
            }

            services.AddMediatR();
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
            app.UseEndpoints(configure =>
            {
                configure.MapControllers();
            });
        }
    }
}
