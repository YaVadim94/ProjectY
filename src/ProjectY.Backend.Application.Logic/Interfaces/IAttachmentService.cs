using System.Threading.Tasks;
using ProjectY.Backend.Application.AmazonS3.Models;
using ProjectY.Backend.Application.Models.Attachments;

namespace ProjectY.Backend.Application.Logic.Interfaces
{
    /// <summary>
    /// Сервис для работы с приложениями(объектами)
    /// </summary>
    public interface IAttachmentService
    {
        /// <summary>
        /// Сохранить файл
        /// </summary>
        Task<AttachmentDto> PutFile(PutObjectDto obj);

        /// <summary>
        /// Получить адрес объекта по идентификатору приложения
        /// </summary>
        Task<string> GetObjectUrl(long attachmentId);
    }
}
