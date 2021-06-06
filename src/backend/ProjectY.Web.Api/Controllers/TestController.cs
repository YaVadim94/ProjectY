using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectY.Data.Entities;
using ProjectY.Logic.Interfaces;
using ProjectY.Logic.Models;
using ProjectY.Logic.Services;

namespace ProjectY.Web.Api.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<IEnumerable<Home>> CreateHome() =>
            await _testService.GetAllAsync();

        [HttpPost]
        public async Task<AddHomeDto> CreateHome([FromBody] [Required] AddHomeDto request)
        {
            var result = await _testService.CreateHomeAsync(request);
            return result;
        }
    }
}
