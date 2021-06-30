using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectY.Frontend.Services.ShoesService
{
    /// <summary>
    /// Сервис для работы с обувью
    /// </summary>
    public class ShoesService : IShoesService
    {
        /// <summary>
        /// Получить список всех моделей
        /// </summary>
        public Task<IEnumerable<object>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
