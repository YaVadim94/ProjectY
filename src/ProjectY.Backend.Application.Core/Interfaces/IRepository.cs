using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Core.Interfaces
{
    /// <summary>
    /// Репозиторий для работы с БД.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущностного класса</typeparam>
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        /// <summary>
        /// Получить сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Найденная сущность</returns>
        Task<TEntity> GetById(int id, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Получить все сущности.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Найденные сущности</returns>
        Task<List<TEntity>> ListAll(CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Получить сущности по спецификации.
        /// </summary>
        /// <param name="spec">Спецификация</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Найденные сущности</returns>
        Task<List<TEntity>> List(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Получить сущности по спецификации, которая имеет функцию-селектор.
        /// </summary>
        /// <param name="spec">Спецификация</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Найденные сущности как проекции функции-селектора</returns>
        Task<List<TResult>> List<TResult>(ISpecification<TEntity, TResult> spec,
            CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Добавить новую сущность.
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Добавленная сущность</returns>
        Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Обновить сущность.
        /// </summary>
        /// <param name="entity">Сущность с новыми значениями полей</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Обновленная сущность</returns>
        Task Update(TEntity entity, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Удалить сущность.
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Результат асинхронной операции</returns>
        Task Delete(TEntity entity, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Получить количество найденных записей.
        /// </summary>
        /// <param name="spec">Спецификация</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Количество найденных записей</returns>
        Task<int> Count(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Получить первую найденную сущность по спецификации.
        /// </summary>
        /// <param name="spec">Спецификация</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Найденная сущность</returns>
        Task<TEntity> First(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Получить первую найденную сущность по спецификации.
        /// </summary>
        /// <param name="spec">Спецификация</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Найденная сущность или значение по умолчанию</returns>
        Task<TEntity> FirstOrDefault(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Получить первую найденную сущность по спецификации, у которой присутсвует функция-селектор.
        /// </summary>
        /// <param name="spec">Спецификация с функцией-селектором</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Проекция функции-селектора или значение по умолчанию</returns>
        Task<TResult> FirstOrDefault<TResult>(ISpecification<TEntity, TResult> spec,
            CancellationToken cancellationToken = default);
    }
}
