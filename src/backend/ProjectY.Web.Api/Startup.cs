using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProjectY.Data;
using Microsoft.Extensions.Configuration;
using ProjectY.Logic.Interfaces;
using ProjectY.Logic.Services;

namespace ProjectY.Web.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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
            services.AddSwaggerGen();

            services.AddScoped<ITestService, TestService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project Y API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting().UseEndpoints(configure => configure.MapControllers());
        }
    }
}
