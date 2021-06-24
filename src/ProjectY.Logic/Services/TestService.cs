using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectY.Backend.Application.Logic.Interfaces;
using ProjectY.Backend.Application.Logic.Models.Home;
using ProjectY.Backend.Data.Entities;
using ProjectY.Data;
using System.Threading.Tasks;

namespace ProjectY.Backend.Application.Logic.Services
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

        public async Task<HomeDto> CreateAsync(CreateHomeDto homeDto)
        {
            var home = _mapper.Map<Home>(homeDto);

            await _context.AddAsync(home);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(home.Id);
        }

        public async Task<HomeDto> GetByIdAsync(long id)
        {
            var home = await _context.Homes
                .AsNoTracking()
                .SingleOrDefaultAsync(h => h.Id == id);

            return _mapper.Map<HomeDto>(home);
        }
    }
}
