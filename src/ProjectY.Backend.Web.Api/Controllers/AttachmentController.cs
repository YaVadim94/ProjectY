using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectY.Backend.Application.AmazonS3.Models;
using ProjectY.Backend.Application.Logic.Interfaces;
using ProjectY.Shared.Contracts.AttachmentsController;

namespace ProjectY.Backend.Web.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с объектами(приложениями)
    /// </summary>
    public class AttachmentController : ApiControllerBase
    {
        private readonly IAttachmentService _attachmentService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Контроллер для работы с объектами(приложениями)
        /// </summary>
        public AttachmentController(IAttachmentService attachmentService, IMapper mapper)
        {
            _attachmentService = attachmentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Поместить файл в хранилище
        /// </summary>
        [HttpPost("put-file")]
        public async Task<AttachmentContract> PutFile(IFormFile file)
        {
            await using var stream = file.OpenReadStream();

            var putObjectDto = new PutObjectDto
            {
                ContentType = file.ContentType,
                Key = Guid.NewGuid().ToString(),
                InputStream = stream,
                FileName = file.FileName,
                FileSize = file.Length
            };

            var attachment = await _attachmentService.PutFile(putObjectDto);

            return _mapper.Map<AttachmentContract>(attachment);
        }

        /// <summary>
        /// Получить адрес файла по идентификатору приложения
        /// </summary>
        [HttpGet("{attachmentId}")]
        public async Task GetUrl(long attachmentId) =>
            await _attachmentService.GetObjectUrl(attachmentId);
    }
}
