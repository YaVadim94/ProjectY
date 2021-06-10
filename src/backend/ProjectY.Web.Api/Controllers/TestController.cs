﻿using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectY.Logic.Interfaces;
using ProjectY.Logic.Models.Home;
using ProjectY.Web.Api.Contracts.Home;

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
        /// Создать запись Home.
        /// </summary>
        [HttpPost]
        public async Task<HomeContract> CreateHome([FromBody][Required] CreateHomeContract request)
        {
            var homeDto = _mapper.Map<CreateHomeDto>(request);
            var result = await _testService.CreateAsync(homeDto);
            return _mapper.Map<HomeContract>(result);
        }
    }
}
