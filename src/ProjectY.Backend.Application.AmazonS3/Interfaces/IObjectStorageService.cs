using System.Threading.Tasks;
using ProjectY.Backend.Application.AmazonS3.Models;

namespace ProjectY.Backend.Application.AmazonS3.Interfaces
{
    /// <summary>
    /// Сервис для работы с объектным хранилищем
    /// </summary>
    public interface IObjectStorageService
    {
        /// <summary>
        /// Создать бакет, если ещё создан
        /// </summary>
        Task CreateBucketIfNotExists(string bucketName);

        /// <summary>
        /// Поместить объект в хранилище
        /// </summary>
        Task PutObject(PutObjectDto obj);

        /// <summary>
        /// Получить объект по ключу
        /// </summary>
        string GetObjectUrl(string key);

        /// <summary>
        /// Удалить файл из хранилища
        /// </summary>
        Task DeleteObject(DeleteObjectDto obj);
    }
}
