using System.Threading.Tasks;
using ProjectY.Frontend.Brokers.Api;
using ProjectY.Frontend.Models;
using ProjectY.Shared.Contracts.TestController;

namespace ProjectY.Frontend.Services.TestService
{
    /// <summary>
    /// 
    /// </summary>
    public class TestService : ITestService
    {
        private readonly IApiBroker _apiBroker;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiBroker"></param>
        public TestService(IApiBroker apiBroker)
        {
            _apiBroker = apiBroker;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task CreateHome(Home home)
        {
            await _apiBroker.CreateHome(new CreateHomeContract { Number = home.Number });
        }
    }
}
