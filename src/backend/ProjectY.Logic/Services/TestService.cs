using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectY.Data;
using ProjectY.Data.Entities;
using ProjectY.Logic.Models;

namespace ProjectY.Logic.Services
{
    public class TestService/*<TEntity> where TEntity : class*/
    {
        private readonly DataContext _context;
        private readonly DbSet<Home> _dbSet;

        public TestService(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<Home>();
        }

        public async Task<AddHomeDto> CreateHomeAsync(AddHomeDto homeDto)
        {
            var home = new Home { Number = homeDto.Number };
            _context.Add(home);
            await _context.SaveChangesAsync();
            return homeDto;
        }
    }
}
