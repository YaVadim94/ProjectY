using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectY.Backend.Application.Logic.Interfaces;
using ProjectY.Backend.Application.Logic.Models.Shoes;
using ProjectY.Backend.Data;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Logic.Services
{
    /// <summary>
    /// Сервис для работы с обувью.
    /// </summary>
    public class ShoesService : IShoesService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор сервиса для работы с обувью.
        /// </summary>
        public ShoesService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Создать обувь.
        /// </summary>
        public async Task<ShoesDto> CreateAsync(CreateShoesDto createShoesDto)
        {
            var createdShoes = _mapper.Map<Shoes>(createShoesDto);

            await _context.AddAsync(createdShoes);
            await _context.SaveChangesAsync();

            return _mapper.Map<ShoesDto>(createdShoes);
        }

        /// <summary>
        /// Получить обувь по идентификатору.
        /// </summary>
        public async Task<ShoesDto> GetByIdAsync(long id)
        {
            var shoes = await _context.Shoes
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == id);

            return _mapper.Map<ShoesDto>(shoes);
        }

        /// <summary>
        /// Получить все экземпляры обуви.
        /// </summary>
        public async Task<IEnumerable<ShoesDto>> GetAllAsync()
        {
            var allShoes = await _context.Shoes
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<ShoesDto>>(allShoes);
        }
    }
}
