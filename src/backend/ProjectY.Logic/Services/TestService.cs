using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectY.Data;
using ProjectY.Data.Entities;
using ProjectY.Logic.Interfaces;
using ProjectY.Logic.Models;

namespace ProjectY.Logic.Services
{
    public class TestService : ITestService
    {
        private readonly DataContext _context;

        public TestService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Home>> GetAllAsync() =>
            await _context.Homes.ToListAsync();

        public async Task<AddHomeDto> CreateHomeAsync(AddHomeDto homeDto)
        {
            var home = new Home { Number = homeDto.Number };
            _context.Add(home);
            await _context.SaveChangesAsync();
            return homeDto;
        }
    }
}
