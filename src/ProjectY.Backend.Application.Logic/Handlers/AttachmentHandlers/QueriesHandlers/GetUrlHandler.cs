using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectY.Backend.Application.AmazonS3.Interfaces;
using ProjectY.Backend.Application.Models.Attachments;
using ProjectY.Backend.Application.Models.Attachments.Queries;
using ProjectY.Backend.Data;

namespace ProjectY.Backend.Application.Logic.Handlers.AttachmentHandlers.QueriesHandlers
{
    /// <summary>
    /// Обработчик для получения адреса объекта
    /// </summary>
    public class GetUrlHandler : IRequestHandler<GetUrlQuery, AttachmentDto>
    {
        private readonly DataContext _dataContext;
        private readonly IObjectStorageService _objectStorageService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Обработчик для получения адреса объекта
        /// </summary>
        public GetUrlHandler(DataContext dataContext, IObjectStorageService objectStorageService, IMapper mapper)
        {
            _dataContext = dataContext;
            _objectStorageService = objectStorageService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить адрес объекта
        /// </summary>
        public async Task<AttachmentDto> Handle(GetUrlQuery request, CancellationToken cancellationToken)
        {
            var attachmentEntity =
                await _dataContext.Attacments.SingleOrDefaultAsync(x => x.Id == request.AttachmentId)
                ?? throw new FileNotFoundException("Приложения с указанным идентификатором не существует");

            var objectUrl = _objectStorageService.GetUrl(attachmentEntity.Key)
                            ?? string.Empty;

            var attachmentDto = _mapper.Map<AttachmentDto>(attachmentEntity, opt =>
                opt.AfterMap((_, d) => d.Url = objectUrl));
            
            return attachmentDto;
        }
    }
}
