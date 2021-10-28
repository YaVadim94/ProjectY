using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectY.Backend.Application.Core.Interfaces;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Data
{
    /// <summary>
    /// Реализация репозитория для работы с БД с помощью EF Core.
    /// </summary>
    /// <typeparam name="T">Тип сущностного класса</typeparam>
    public class EFRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DataContext _context;
        private readonly ISpecificationEvaluator _specificationEvaluator;


        public EFRepository(DataContext context) : this(context, SpecificationEvaluator.Default)
        {
        }

        public EFRepository(DataContext context, ISpecificationEvaluator specificationEvaluator)
        {
            _context = context;
            _specificationEvaluator = specificationEvaluator;
        }

        public async Task<T> GetById(long id)
        {
            var keyValues = new object[] { id };

            return await _context.Set<T>().FindAsync(keyValues);
        }

        public async Task<List<T>> List(ISpecification<T> spec)
        {
            var specificationResult = ApplySpecification(spec);

            return await specificationResult.ToListAsync();
        }

        public async Task<int> Count(ISpecification<T> spec)
        {
            var specificationResult = ApplySpecification(spec);

            return await specificationResult.CountAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> FirstOrDefault(ISpecification<T> spec)
        {
            var specificationResult = ApplySpecification(spec);

            return await specificationResult.FirstOrDefaultAsync();
        }

        public async Task<T> First(ISpecification<T> spec)
        {
            var specificationResult = ApplySpecification(spec);

            return await specificationResult.FirstAsync();
        }

        public async Task<List<T>> ListAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<TResult>> List<TResult>(ISpecification<T, TResult> spec)
        {
            var specificationResult = ApplySpecification(spec);

            return await specificationResult.ToListAsync();
        }

        public async Task<TResult> FirstOrDefault<TResult>(ISpecification<T, TResult> spec)
        {
            var specificationResult = ApplySpecification(spec);

            return await specificationResult.FirstOrDefaultAsync();
        }

        #region Private methods

        /// <summary>
        /// Примменить спецификацию.
        /// </summary>
        /// <param name="spec">Спецификация</param>
        /// <returns>Запрос</returns>
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return _specificationEvaluator.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        /// <summary>
        /// Примменить спецификацию c функцией-селектором.
        /// </summary>
        /// <param name="specification">Спецификация</param>
        /// <typeparam name="TResult">Класс-проекция</typeparam>
        /// <returns>Запрос</returns>
        private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification)
        {
            return _specificationEvaluator.GetQuery(_context.Set<T>(), specification);
        }

        #endregion
    }
}
