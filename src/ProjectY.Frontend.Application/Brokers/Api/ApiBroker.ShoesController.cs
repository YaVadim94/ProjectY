using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectY.Shared.Contracts.ShoesController;

namespace ProjectY.Frontend.Application.Brokers.Api
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ApiBroker : ApiBrokerBase, IApiBroker
    {
        private const string controllerUrl = "api/shoes";

        /// <summary>
        /// Создать обувь
        /// </summary>
        public async Task<ShoesContracts> CreateShoes(CreateShoesContract request) =>
            await PostAsync<CreateShoesContract, ShoesContracts>(controllerUrl, request);

        /// <summary>
        /// Получить обувь по идентификатору
        /// </summary>
        public async Task<ShoesContracts> GetShoesById(long id) =>
            await GetAsync<ShoesContracts>($"{controllerUrl}/{id}");

        /// <summary>
        /// Получить обувь по идентификатору
        /// </summary>
        public async Task<IEnumerable<ShoesContracts>> GetAllShoes(string oDataString) =>
            await GetAsync<IEnumerable<ShoesContracts>>(controllerUrl, oDataString);
    }
}
