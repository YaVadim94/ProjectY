using System.Threading.Tasks;
using ProjectY.Shared.Contracts.TestController;

namespace ProjectY.Frontend.Application.Brokers.Api.TestBroker
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITestBroker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<HomeContract> CreateHome(CreateHomeContract request);
    }
}
