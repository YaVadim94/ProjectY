using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using ProjectY.Frontend.Application.Brokers.Api.Interfaces;
using ProjectY.Frontend.Application.Models.Files;
using ProjectY.Shared.Contracts.AttachmentsController;

namespace ProjectY.Frontend.Application.Services.FileService
{
    /// <summary>
    /// Сервис для работы с файлами
    /// </summary>
    public class FileService : IFileService
    {
        private readonly IAttachmentApiBroker _attachmentApiBroker;

        /// <summary>
        /// Сервис для работы с файлами
        /// </summary>
        public FileService(IAttachmentApiBroker attachmentApiBroker)
        {
            _attachmentApiBroker = attachmentApiBroker;
        }

        /// <summary>
        /// Загрузить файл в хранилище
        /// </summary>
        public async Task<object> UploadFile(FileUploadModel file)
        {
            await using var stream = new FileStream(file.Url, FileMode.Create);
            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(stream));

            var contract = new PutFileContractFrontend {FileName = file.Name, File = content};

            var response = await _attachmentApiBroker.Upload(contract);
            return response;
        }

        /// <summary>
        /// Получить адрес картинки по идентификатору приложения
        /// </summary>
        public async Task<string> GetUrl(long attachmentId)
        {
            var attachmentContract = await _attachmentApiBroker.GetUrl(attachmentId);

            return attachmentContract.Url;
        }
    }
}
