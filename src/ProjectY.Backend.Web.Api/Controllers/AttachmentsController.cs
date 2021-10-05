using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectY.Backend.Application.Models.Attachments.Commands;
using ProjectY.Backend.Application.Models.Attachments.Queries;
using ProjectY.Shared.Contracts.AttachmentsController;

namespace ProjectY.Backend.Web.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с объектами(приложениями)
    /// </summary>
    public class AttachmentsController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Контроллер для работы с объектами(приложениями)
        /// </summary>
        public AttachmentsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Поместить файл в хранилище
        /// </summary>
        [HttpPost]
        public async Task<AttachmentContract> PutFile(IFormFile file)
        {
            await using var stream = file.OpenReadStream();

            // TODO: написать кастомный маппинг
            var putObjectCommand = _mapper.Map<PutObjectCommand>(file);
            putObjectCommand.InputStream = stream;

            var attachment = await _mediator.Send(putObjectCommand);

            return _mapper.Map<AttachmentContract>(attachment);
        }

        /// <summary>
        /// Получить адрес файла по идентификатору приложения
        /// </summary>
        [HttpGet("{attachmentId}")]
        public async Task<AttachmentContract> GetUrl(long attachmentId)
        {
            var getUrlQuery = new GetUrlQuery {AttachmentId = attachmentId};

            var attachmentDto = await _mediator.Send(getUrlQuery);

            return _mapper.Map<AttachmentContract>(attachmentDto);
        }
    }
}
