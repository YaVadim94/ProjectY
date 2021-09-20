using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectY.Backend.Data;
using ProjectY.Backend.Data.Extensions;
using ProjectY.Backend.Web.Api.Extensions;
using ProjectY.Backend.Web.Api.Filters;
using ProjectY.Backend.Web.Api.Middleware;
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
                .ReadFrom.Configuration(configuration, "Serilog")
                .CreateLogger();
        }

        /// <summary>
        /// Сидирование DI
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            // IMvcBuilder
            services
                .AddControllers(conf =>
                {
                    conf.Filters.Add(new ValidationFilter());
                })
                .ConfigureApiBehaviorOptions(opt =>
                {
                    opt.SuppressModelStateInvalidFilter = true;
                })
                .AddOData(opt => opt.Filter().OrderBy().SkipToken().SetMaxTop(int.MaxValue))
                .AddNewtonsoftJson();

            // IServiceCollection
            services
                .AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                        builder.WithOrigins("http://localhost:3000", "https://localhost:3001")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
                })
                .AddRepositoryContext(opt =>
                {
                    opt.ConnectionString = _configuration.GetConnectionString("Postgres");
                })
                .AddAutoMapper()
                .AddMediatR()
                .AddFluentValidation()
                .AddObjectStorage(_configuration);

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
            app.UseEndpoints(configure =>
            {
                configure.MapControllers();
            });
        }
    }
}
