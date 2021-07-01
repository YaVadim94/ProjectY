using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectY.Frontend.Application.Brokers.Api;
using ProjectY.Shared.Contracts.ShoesController;

namespace ProjectY.Frontend.Application.Services.ShoesService
{
    /// <summary>
    /// Сервис для работы с обувью
    /// </summary>
    public class ShoesService : IShoesService
    {
        private readonly IApiBroker _apiBroker;

        /// <summary>
        /// Сервис для работы с обувью
        /// </summary>
        public ShoesService(IApiBroker apiBroker)
        {
            _apiBroker = apiBroker;
        }

        /// <summary>
        /// Получить список всех моделей
        /// </summary>
        public async Task<IEnumerable<ShoesContracts>> GetAll()
        {
            return await _apiBroker.GetAllShoes();
        }
    }
}
