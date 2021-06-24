using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ProjectY.Web.Api
{
    /// <summary>
    /// �������� ����� ����������
    /// </summary>
    public class Program
    {
        /// <summary>
        /// �������� ����� ����������
        /// </summary>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .UseSerilog()
                .Build().Run();
        }

        /// <summary>
        /// ������������ ��� �����
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
