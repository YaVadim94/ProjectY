using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using ProjectY.Backend.Application.Logic.Interfaces;
using ProjectY.Backend.Application.Models.Shoes;
using ProjectY.Backend.Application.Models.Shoes.Commands;
using ProjectY.Backend.Application.Models.Shoes.Queries;

namespace ProjectY.Backend.Application.Logic.Services
{
    /// <summary>
    /// Сервис для работы с обувью.
    /// </summary>
    public class ShoesService : IShoesService
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Конструктор сервиса для работы с обувью.
        /// </summary>
        public ShoesService(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Создать обувь.
        /// </summary>
        public async Task<ShoesDto> CreateAsync(CreateShoesCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Получить обувь по идентификатору.
        /// </summary>
        public async Task<ShoesDto> GetByIdAsync(long id)
        {
            var query = new GetShoesByIdQuery(id);
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Получить все экземпляры обуви.
        /// </summary>
        public async Task<IEnumerable<ShoesDto>> GetAllAsync()
        {
            var query = new GetAllShoesQuery();
            return await _mediator.Send(query);
        }
    }
}
