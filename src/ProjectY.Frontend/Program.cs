using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProjectY.Frontend.Extensions;

namespace ProjectY.Frontend
{
    /// <summary>
    /// Проект фронта
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Входной метод
        /// </summary>
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.ConfigureBrokers(builder.Configuration.GetSection("ApiConfigurations")
                .GetSection("Url").Value);

            builder.Services.AddServices();
            builder.Services.AddAntDesign();

            await builder.Build().RunAsync();
        }
    }
}
