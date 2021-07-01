using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ProjectY.Backend.Web.Api
{
    /// <summary>
    /// Исходный класс приложения
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Исходный метод приложения
        /// </summary>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .UseSerilog()
                .Build().Run();
        }

        /// <summary>
        /// Конфигурация веб хоста
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
