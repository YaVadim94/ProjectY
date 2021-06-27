using System.Threading.Tasks;
using ProjectY.Shared.Contracts.TestController;

namespace ProjectY.Frontend.Brokers.Api
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ApiBroker : ApiBrokerBase, IApiBroker
    {
        private const string controllerUrl = "api/test";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HomeContract> CreateHome(CreateHomeContract request) =>
            await PostAsync<CreateHomeContract, HomeContract>($"{controllerUrl}", request);
    }
}
