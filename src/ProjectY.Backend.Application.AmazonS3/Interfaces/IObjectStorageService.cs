using System.Threading.Tasks;

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
    }
}
