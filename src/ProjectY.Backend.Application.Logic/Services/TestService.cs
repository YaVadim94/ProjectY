using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectY.Backend.Application.Logic.Interfaces;
using ProjectY.Backend.Application.Logic.Models.Home;
using ProjectY.Backend.Data;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Logic.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TestService : ITestService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public TestService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="homeDto"></param>
        /// <returns></returns>
        public async Task<HomeDto> CreateAsync(CreateHomeDto homeDto)
        {
            var home = _mapper.Map<Home>(homeDto);

            await _context.AddAsync(home);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(home.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HomeDto> GetByIdAsync(long id)
        {
            var home = await _context.Homes
                .AsNoTracking()
                .SingleOrDefaultAsync(h => h.Id == id);

            return _mapper.Map<HomeDto>(home);
        }
    }
}
