using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectY.Backend.Application.Models.Shoes;
using ProjectY.Backend.Application.Models.Shoes.Commands;

namespace ProjectY.Backend.Application.Logic.Interfaces
{
    /// <summary>
    /// Сервис для работы с обувью.
    /// </summary>
    public interface IShoesService
    {
        /// <summary>
        /// Создать обувь.
        /// </summary>
        Task<ShoesDto> CreateAsync(CreateShoesCommand createShoesDto);

        /// <summary>
        /// Получить обувь по идентификатору.
        /// </summary>
        Task<ShoesDto> GetByIdAsync(long id);

        /// <summary>
        /// Получить все экземпляры обуви.
        /// </summary>
        Task<IEnumerable<ShoesDto>> GetAllAsync();
    }
}
