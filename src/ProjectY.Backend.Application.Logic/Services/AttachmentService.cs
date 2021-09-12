using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectY.Backend.Application.AmazonS3.Interfaces;
using ProjectY.Backend.Application.AmazonS3.Models;
using ProjectY.Backend.Application.Logic.Interfaces;
using ProjectY.Backend.Application.Models.Attachments;
using ProjectY.Backend.Data;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Logic.Services
{
    /// <summary>
    /// Сервис для работы с приложениями(объектами)
    /// </summary>
    public class AttachmentService : IAttachmentService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IObjectStorageService _objectStorageService;

        /// <summary>
        /// Сервис для работы с приложениями(объектами)
        /// </summary>
        public AttachmentService(IObjectStorageService objectStorageService, DataContext dataContext, IMapper mapper)
        {
            _objectStorageService = objectStorageService;
            _dataContext = dataContext;
            _mapper = mapper;
        }


        /// <summary>
        /// Сохранить файл
        /// </summary>
        public async Task<AttachmentDto> PutFile(PutObjectDto obj)
        {
            //TODO: Продумать обработку исключения
            await _objectStorageService.PutObject(obj);

            var objectUrl = _objectStorageService.GetObjectUrl(obj.Key);

            var attachmentEntity = _mapper.Map<Attachment>(obj, opt =>
                opt.AfterMap((_, d) => d.Url = objectUrl));

            await _dataContext.AddAsync(attachmentEntity);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<AttachmentDto>(attachmentEntity);
        }

        /// <summary>
        /// Получить адрес объекта по идентификатору приложения
        /// </summary>
        public async Task<string> GetObjectUrl(long attachmentId)
        {
            var attachmentEntity =
                await _dataContext.Attacments.SingleOrDefaultAsync(x => x.Id == attachmentId)
                ?? throw new FileNotFoundException("Приложения с указанным идентификатором не существует");

            var objectUrl = _objectStorageService.GetObjectUrl(attachmentEntity.Key)
                            ?? string.Empty;

            return objectUrl;
        }
    }
}
