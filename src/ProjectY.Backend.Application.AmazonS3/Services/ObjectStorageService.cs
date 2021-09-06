using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using ProjectY.Backend.Application.AmazonS3.Interfaces;
using ProjectY.Backend.Application.AmazonS3.Models;

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

        /// <summary>
        /// Удалить файл из хранилища
        /// </summary>
        public async Task DeleteObject(DeleteObjectDto obj)
        {
            var request = new DeleteObjectRequest
            {
                Key = obj.Key,
                BucketName = obj.BucketName
            };

            var response = await _amazonS3Client.DeleteObjectAsync(request);
            //TODO: Изучить ответ при попытке удаления объекта, которого нет в хранилище
        }

        /// <summary>
        /// Получить объект по идентификатору
        /// </summary>
        public string GetObjectUrl(GetObjectUrlDto obj)
        {
            var request = new GetPreSignedUrlRequest
            {
                Key = obj.Key,
                BucketName = obj.BucketName
            };

            var response = _amazonS3Client.GetPreSignedURL(request);

            //TODO: Нужен свой эксепшн
            return string.IsNullOrEmpty(response)
                ? throw new FileNotFoundException("Указанного файла не существует")
                : response;
        }

        /// <summary>
        /// Поместить объект в хранилище
        /// </summary>
        public async Task<object> PutObject(PutObjectDto obj)
        {
            var ss = await _amazonS3Client.ListBucketsAsync();

            await CreateBucketIfNotExists(obj.BucketName);

            var request = new PutObjectRequest
            {
                Key = obj.Key,
                ContentType = obj.ContentType,
                BucketName = obj.BucketName,
                InputStream = obj.InputStream,

            };

            var response = await _amazonS3Client.PutObjectAsync(request);

            //TODO: Скорее всего, тут нужно будет возвращать какую-то метадату объекта
            //Возможно, получится размаппить респонс, если нет, то можно запросить мету через клиента
            return null;
        }
    }
}
