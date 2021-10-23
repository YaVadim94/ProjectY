using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public async Task<T> GetById(int id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            
            return await _context.Set<T>().FindAsync(keyValues, cancellationToken);
        }

        public async Task<List<T>> ListAll(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken: cancellationToken);
        }
        
        public async Task<List<T>> List(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            
            return await specificationResult.ToListAsync(cancellationToken);
        }
        
        public async Task<List<TResult>> List<TResult>(ISpecification<T, TResult> spec,
            CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            
            return await specificationResult.ToListAsync(cancellationToken);
        }
        
        public async Task<int> Count(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            
            return await specificationResult.CountAsync(cancellationToken);
        }

        public async Task<T> Add(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task Update(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<T> FirstOrDefault(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            
            return await specificationResult.FirstOrDefaultAsync(cancellationToken);
        }
        
        public async Task<TResult> FirstOrDefault<TResult>(ISpecification<T, TResult> spec,
            CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            
            return await specificationResult.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<T> First(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            
            return await specificationResult.FirstAsync(cancellationToken);
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
