using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectY.Frontend.Application.Brokers.Api;

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
        public Task<IEnumerable<object>> GetAll()
        {
            throw new System.Exception();
        }
    }
}
