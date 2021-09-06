using System.Threading.Tasks;
using ProjectY.Frontend.Application.Models.Files;

namespace ProjectY.Frontend.Application.Services.FileService
{
    /// <summary>
    /// Сервис для работы с файлами
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Загрузить файл в хранилище
        /// </summary>
        Task<object> UploadFile(FileUploadModel file);
    }
}
