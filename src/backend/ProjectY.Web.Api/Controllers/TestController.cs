using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectY.Logic.Models;
using ProjectY.Logic.Services;

namespace ProjectY.Web.Api.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly TestService _testService;

        public TestController(TestService testService)
        {
            _testService = testService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHome([FromBody] [Required] AddHomeDto request)
        {
            var result = await _testService.CreateHomeAsync(request);
            return Ok(result);
        }
    }
}
