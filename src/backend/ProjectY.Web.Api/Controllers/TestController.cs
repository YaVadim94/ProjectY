using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectY.Data.Entities;
using ProjectY.Logic.Interfaces;
using ProjectY.Logic.Models;
using ProjectY.Web.Api.Contracts.Requests;
using ProjectY.Web.Api.Contracts.Responses;

namespace ProjectY.Web.Api.Controllers
{
    /// <summary>
    /// Тестовый контроллер для отладки проекта.
    /// </summary>
    public class TestController : BaseApiController
    {
        private readonly ITestService _testService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Тестовый контроллер для отладки проекта.
        /// </summary>
        public TestController(ITestService testService, IMapper mapper)
        {
            _testService = testService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить все записи Home.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Home>> GetAll() =>
            await _testService.GetAllAsync();

        /// <summary>
        /// Создать запись Home.
        /// </summary>
        [HttpPost]
        public async Task<CreatedHomeDto> CreateHome([FromBody][Required] CreateHomeDto request)
        {
            var homeDto = _mapper.Map<HomeDto>(request);
            var result = await _testService.CreateHomeAsync(homeDto);
            return _mapper.Map<CreatedHomeDto>(result);
        }
    }
}
