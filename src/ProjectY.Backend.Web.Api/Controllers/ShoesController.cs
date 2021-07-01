using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectY.Backend.Application.Logic.Interfaces;
using ProjectY.Backend.Application.Logic.Models.Shoes;
using ProjectY.Shared.Contracts.ShoesController;
using ProjectY.Web.Api.Controllers;

namespace ProjectY.Backend.Web.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с обувью.
    /// </summary>
    public class ShoesController : BaseApiController
    {
        private readonly IShoesService _shoesService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор контроллера для работы с обувью.
        /// </summary>
        public ShoesController(IShoesService shoesService, IMapper mapper)
        {
            _shoesService = shoesService;
            _mapper = mapper;
        }


        /// <summary>
        /// Создать обувь.
        /// </summary>
        /// <returns>Контракт для обуви</returns>
        [HttpPost]
        public async Task<ShoesContracts> CreateShoes(CreateShoesContract request)
        {
            var createdShoesDto = _mapper.Map<CreateShoesDto>(request);

            var result = await _shoesService.CreateAsync(createdShoesDto);

            return _mapper.Map<ShoesContracts>(result);
        }

        /// <summary>
        /// Получить обувь по идентификатору.
        /// </summary>
        /// <returns>Контракт для обуви</returns>
        [HttpGet("{id}")]

        public async Task<ShoesContracts> GetShoesById(long id)
        {
            var result = await _shoesService.GetByIdAsync(id);

            return _mapper.Map<ShoesContracts>(result);
        }

        /// <summary>
        /// Получить обувь по идентификатору.
        /// </summary>
        /// <returns>Список контрактов обуви</returns>
        [HttpGet]
        public async Task<IEnumerable<ShoesContracts>> GetAllShoes()
        {
            var result = await _shoesService.GetAllAsync();

            return _mapper.Map<IEnumerable<ShoesContracts>>(result);
        }
    }
}
