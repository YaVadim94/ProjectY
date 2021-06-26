using System.Net.Http;
using System.Threading.Tasks;
using ProjectY.Shared.Contracts.TestController;

namespace ProjectY.Frontend.Application.Brokers.Api.TestBroker
{
    /// <summary>
    /// 
    /// </summary>
    public class TestBroker : ApiBrokerBase, ITestBroker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClient"></param>
        public TestBroker(HttpClient httpClient) : base(httpClient) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<HomeContract> CreateHome(CreateHomeContract request)
        {
            throw new System.NotImplementedException();
        }
    }
}
