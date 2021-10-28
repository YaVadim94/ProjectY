using System.Collections.Generic;
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
        /// <returns>Найденная сущность</returns>
        Task<TEntity> GetById(long id);

        /// <summary>
        /// Получить все сущности.
        /// </summary>
        /// <returns>Найденные сущности</returns>
        Task<List<TEntity>> ListAll();

        /// <summary>
        /// Получить сущности по спецификации.
        /// </summary>
        /// <param name="spec">Спецификация</param>
        /// <returns>Найденные сущности</returns>
        Task<List<TEntity>> List(ISpecification<TEntity> spec);

        /// <summary>
        /// Получить сущности по спецификации, которая имеет функцию-селектор.
        /// </summary>
        /// <param name="spec">Спецификация</param>
        /// <returns>Найденные сущности как проекции функции-селектора</returns>
        Task<List<TResult>> List<TResult>(ISpecification<TEntity, TResult> spec);

        /// <summary>
        /// Добавить новую сущность.
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        /// <returns>Добавленная сущность</returns>
        Task Add(TEntity entity);

        /// <summary>
        /// Обновить сущность.
        /// </summary>
        /// <param name="entity">Сущность с новыми значениями полей</param>
        /// <returns>Обновленная сущность</returns>
        Task Update(TEntity entity);

        /// <summary>
        /// Удалить сущность.
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        /// <returns>Результат асинхронной операции</returns>
        Task Delete(TEntity entity);

        /// <summary>
        /// Получить количество найденных записей.
        /// </summary>
        /// <param name="spec">Спецификация</param>
        /// <returns>Количество найденных записей</returns>
        Task<int> Count(ISpecification<TEntity> spec);

        /// <summary>
        /// Получить первую найденную сущность по спецификации.
        /// </summary>
        /// <param name="spec">Спецификация</param>
        /// <returns>Найденная сущность</returns>
        Task<TEntity> First(ISpecification<TEntity> spec);

        /// <summary>
        /// Получить первую найденную сущность по спецификации.
        /// </summary>
        /// <param name="spec">Спецификация</param>
        /// <returns>Найденная сущность или значение по умолчанию</returns>
        Task<TEntity> FirstOrDefault(ISpecification<TEntity> spec);

        /// <summary>
        /// Получить первую найденную сущность по спецификации, у которой присутсвует функция-селектор.
        /// </summary>
        /// <param name="spec">Спецификация с функцией-селектором</param>
        /// <returns>Проекция функции-селектора или значение по умолчанию</returns>
        Task<TResult> FirstOrDefault<TResult>(ISpecification<TEntity, TResult> spec);
    }
}
