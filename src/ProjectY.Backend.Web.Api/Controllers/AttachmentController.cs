using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectY.Backend.Application.AmazonS3.Interfaces;
using ProjectY.Backend.Application.AmazonS3.Models;

namespace ProjectY.Backend.Web.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с объектами(приложениями)
    /// </summary>
    public class AttachmentController : ApiControllerBase
    {
        private readonly IObjectStorageService _objectStorageService;
        private const string bucketName = "media";

        /// <summary>
        /// Контроллер для работы с объектами(приложениями)
        /// </summary>
        public AttachmentController(IObjectStorageService objectStorageService)
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
                BucketName = bucketName,
                ContentType = file.ContentType,
                Key = $"{file.FileName}_{Guid.NewGuid()}",
                InputStream = stream
            };

            await _objectStorageService.PutObject(putObjectDto);

            return NoContent();
        }


    }
}
