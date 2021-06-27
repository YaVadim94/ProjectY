using System.Threading.Tasks;
using ProjectY.Shared.Contracts.TestController;

namespace ProjectY.Frontend.Brokers.Api
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IApiBroker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<HomeContract> CreateHome(CreateHomeContract request);
    }
}
