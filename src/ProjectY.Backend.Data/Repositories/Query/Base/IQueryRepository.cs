using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectY.Backend.Data.Repositories.Query.Base
{
    /// <summary>
    /// Сервис для запросов в БД
    /// </summary>
    /// <typeparam name="T">Ссылочный тип</typeparam>
    public interface IQueryRepository<T> where T : class
    {
        /// <summary>
        /// Получить все записи
        /// </summary>
        Task<IReadOnlyCollection<T>> GetAll();
        
        /// <summary>
        /// Получить запись по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        Task<T> GetById(long id);
    }
}
