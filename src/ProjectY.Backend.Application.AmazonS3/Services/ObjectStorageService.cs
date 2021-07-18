using System.Threading.Tasks;
using Amazon.S3;
using ProjectY.Backend.Application.AmazonS3.Interfaces;

namespace ProjectY.Backend.Application.AmazonS3.Services
{
    /// <summary>
    /// Сервис для работы с объектным хранилищем
    /// </summary>
    public class ObjectStorageService : IObjectStorageService
    {
        private readonly IAmazonS3 _amazonS3Client;

        /// <summary>
        /// Сервис для работы с объектным хранилищем
        /// </summary>
        public ObjectStorageService(IAmazonS3 amazonS3Client)
        {
            _amazonS3Client = amazonS3Client;
        }

        /// <summary>
        /// Создать бакет, если ещё создан
        /// </summary>
        public async Task CreateBucketIfNotExists(string bucketName)
        {
            if (!await _amazonS3Client.DoesS3BucketExistAsync(bucketName))
                await _amazonS3Client.EnsureBucketExistsAsync(bucketName);
        }
    }
}
