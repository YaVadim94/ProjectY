using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ProjectY.Shared.Contracts.ShoesController;

namespace ProjectY.Frontend.Application.Brokers.Api
{
    /// <summary>
    /// Брокер для контроллера по работе с обувью
    /// </summary>
    public class ShoesApiBroker : ApiBrokerBase, IShoesApiBroker
    {
        /// <summary> Относительный адрес контроллера юекенда </summary>
        protected override string ControllerUrl => "api/shoes";

        /// <summary>
        /// Брокер для контроллера по работе с обувью
        /// </summary>
        public ShoesApiBroker(HttpClient httpClient) : base(httpClient) { }

        /// <summary>
        /// Создать обувь
        /// </summary>
        public async Task<ShoesContracts> CreateShoes(CreateShoesContract request) =>
            await PostAsync<CreateShoesContract, ShoesContracts>(string.Empty, request);

        /// <summary>
        /// Получить обувь по идентификатору
        /// </summary>
        public async Task<ShoesContracts> GetShoesById(long id) =>
            await GetAsync<ShoesContracts>($"/{id}");

        /// <summary>
        /// Получить обувь по идентификатору
        /// </summary>
        public async Task<IEnumerable<ShoesContracts>> GetAllShoes(string oDataString) =>
            await GetAsync<IEnumerable<ShoesContracts>>(string.Empty, oDataString);
    }
}
