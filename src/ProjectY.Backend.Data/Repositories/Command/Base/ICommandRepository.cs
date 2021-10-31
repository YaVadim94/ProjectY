using System.Threading.Tasks;

namespace ProjectY.Backend.Data.Repositories.Command.Base
{
    /// <summary>
    /// Сервис для изменения БД.
    /// </summary>
    /// <typeparam name="T">Ссылочный тип</typeparam>
    public interface ICommandRepository<T> where T : class
    {
        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="entity">Экземпляр сущности</param>
        Task Add(T entity);

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity">Экземпляр сущности</param>
        Task Update(T entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="entity">Экземпляр сущности</param>
        Task Delete(T entity);
    }
}
