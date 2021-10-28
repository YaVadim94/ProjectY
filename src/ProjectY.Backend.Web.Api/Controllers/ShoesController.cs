using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectY.Backend.Application.Models.Shoes.Commands;
using ProjectY.Backend.Application.Models.Shoes.Queries;
using ProjectY.Shared.Contracts.ShoesController;

namespace ProjectY.Backend.Web.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с обувью.
    /// </summary>
    public class ShoesController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Конструктор контроллера для работы с обувью.
        /// </summary>
        public ShoesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Создать обувь.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateShoes(CreateShoesContract request)
        {
            var command = _mapper.Map<CreateShoesCommand>(request);

            var result = await _mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// Получить обувь по идентификатору.
        /// </summary>
        /// <returns>Контракт для обуви</returns>
        [HttpGet("{id}")]
        public async Task<ShoesContracts> GetShoesById(long id)
        {
            var query = new GetShoesByIdQuery(id);

            var result = await _mediator.Send(query);

            return _mapper.Map<ShoesContracts>(result);
        }

        /// <summary>
        /// Получить всю обувь.
        /// </summary>
        /// <returns>Список контрактов обуви</returns>
        [HttpGet]
        public async Task<IEnumerable<ShoesContracts>> GetAllShoes()
        {
            var query = new GetAllShoesQuery();

            var result = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<ShoesContracts>>(result);
        }
    }
}
