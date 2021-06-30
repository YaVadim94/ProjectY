using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectY.Frontend.Services
{
    /// <summary>
    /// Сервис для работы с обувью
    /// </summary>
    public interface IShoesService
    {
        /// <summary>
        /// Получить список всех моделей
        /// </summary>
        Task<IEnumerable<object>> GetAll();
    }
}
