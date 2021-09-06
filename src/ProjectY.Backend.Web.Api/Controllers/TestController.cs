using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectY.Backend.Application.AmazonS3.Interfaces;
using ProjectY.Backend.Application.AmazonS3.Models;

namespace ProjectY.Backend.Web.Api.Controllers
{
    /// <summary>
    /// Контроллер для тестов
    /// </summary>
    public class TestingController : ApiControllerBase
    {
        private readonly IObjectStorageService _objectStorageService;

        /// <summary>
        /// Контроллер для тестов
        /// </summary>
        public TestingController(IObjectStorageService objectStorageService)
        {
            _objectStorageService = objectStorageService;
        }

        /// <summary>
        /// Поместить файл в хранилище
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> PutFile(IFormFile file)
        {
            await using var stream = file.OpenReadStream();

            var putObjectDto = new PutObjectDto
            {
                BucketName = "media",
                ContentType = file.ContentType,
                Key = $"{file.FileName}_{Guid.NewGuid()}",
                InputStream = stream
            };

            await _objectStorageService.PutObject(putObjectDto);

            return NoContent();
        }


    }
}
