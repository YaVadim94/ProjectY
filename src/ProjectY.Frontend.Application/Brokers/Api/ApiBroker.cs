using System.Net.Http;

namespace ProjectY.Frontend.Application.Brokers.Api
{
    /// <summary>
    /// Основная имплементация интерфейся <see cref="IApiBroker"/>
    /// </summary>
    public partial class ApiBroker : ApiBrokerBase, IApiBroker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClient"></param>
        public ApiBroker(HttpClient httpClient) : base(httpClient) { }
    }
}
