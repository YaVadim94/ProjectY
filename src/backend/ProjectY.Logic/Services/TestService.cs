using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public TestService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Home>> GetAllAsync() =>
            await _context.Homes.ToListAsync();

        public async Task<HomeDto> CreateHomeAsync(HomeDto homeDto)
        {
            var home = _mapper.Map<Home>(homeDto);
            _context.Add(home);
            await _context.SaveChangesAsync();
            return homeDto;
        }
    }
}
