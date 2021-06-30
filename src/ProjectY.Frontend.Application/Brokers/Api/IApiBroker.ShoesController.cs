using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectY.Shared.Contracts.ShoesController;

namespace ProjectY.Frontend.Application.Brokers.Api
{
    /// <summary>
    /// Брокер для контроллера обуви
    /// </summary>
    public partial interface IApiBroker
    {
        /// <summary>
        /// Создать обувь
        /// </summary>
        Task<ShoesContracts> CreateShoes(CreateShoesContract request);

        /// <summary>
        /// Получить обувь по идентификатору
        /// </summary>
        Task<ShoesContracts> GetShoesById(long id);

        /// <summary>
        /// Получить обувь по идентификатору
        /// </summary>
        Task<IEnumerable<ShoesContracts>> GetAllShoes();
    }
}
