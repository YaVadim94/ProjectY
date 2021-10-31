using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Data.Repositories.Command.Base
{
    public class CommandRepository<T> : ICommandRepository<T> where T : EntityBase
    {
        private readonly DataContext _context;

        protected CommandRepository(DataContext context)
        {
            _context = context;
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
    }
}
