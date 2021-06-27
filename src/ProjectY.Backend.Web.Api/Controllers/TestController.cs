﻿using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectY.Backend.Application.Logic.Interfaces;
using ProjectY.Backend.Application.Logic.Models.Home;
using ProjectY.Shared.Contracts.TestController;

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
        public async Task<HomeContract> CreateHome(CreateHomeContract request)
        {
            var homeDto = _mapper.Map<CreateHomeDto>(request);
            var result = await _testService.CreateAsync(homeDto);
            return _mapper.Map<HomeContract>(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task GetHome()
        {
            await Task.CompletedTask;
        }
    }
}