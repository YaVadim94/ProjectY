using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectY.Backend.Application.AmazonS3.Interfaces;
using ProjectY.Backend.Application.AmazonS3.Models;
using ProjectY.Backend.Application.Models.Attachments;
using ProjectY.Backend.Application.Models.Attachments.Commands;
using ProjectY.Backend.Data;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Logic.Handlers.AttachmentHandlers.CommandHandlers
{
    /// <summary>
    /// Обработчик для помещения файла в хранилища
    /// </summary>
    public class PutFileHandler : IRequestHandler<PutObjectCommand, AttachmentDto>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IObjectStorageService _objectStorageService;

        /// <summary>
        /// Обработчик для помещения файла в хранилища
        /// </summary>
        public PutFileHandler(DataContext dataContext, IMapper mapper, IObjectStorageService objectStorageService)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _objectStorageService = objectStorageService;
        }

        /// <summary>
        /// Поместить файл в хранилище
        /// </summary>
        public async Task<AttachmentDto> Handle(PutObjectCommand request, CancellationToken cancellationToken)
        {
            var putObjectDto = _mapper.Map<PutObjectDto>(request);

            //TODO: Продумать обработку исключения
            await _objectStorageService.PutObject(putObjectDto);

            var attachment = _mapper.Map<Attachment>(putObjectDto);

            await _dataContext.AddAsync(attachment, cancellationToken);

            await _dataContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<AttachmentDto>(attachment);
        }
    }
}
