using System;
using System.IO;
using System.Net;
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
        private const string bucket = "media";
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
        public async Task Delete(DeleteObjectDto obj)
        {
            var request = new DeleteObjectRequest {Key = obj.Key, BucketName = bucket};

            var response = await _amazonS3Client.DeleteObjectAsync(request);
            //TODO: Изучить ответ при попытке удаления объекта, которого нет в хранилище
        }

        /// <summary>
        /// Получить объект по идентификатору
        /// </summary>
        public string GetUrl(string key)
        {
            var request = new GetPreSignedUrlRequest
            {
                Key = key,
                BucketName = bucket,
                Expires = DateTime.UtcNow + TimeSpan.FromHours(1),
                Protocol = Protocol.HTTP
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
        public async Task Put(PutObjectDto obj)
        {
            await CreateBucketIfNotExists(bucket);

            var request = new PutObjectRequest
            {
                Key = obj.Key, ContentType = obj.ContentType, BucketName = bucket, InputStream = obj.InputStream
            };

            request.Metadata.Add(Constants.FileName, obj.FileName);
            request.Metadata.Add(Constants.FileSize, obj.FileSize.ToString());

            var response = await _amazonS3Client.PutObjectAsync(request);

            //TODO: продумать исключения
            if (response.HttpStatusCode != HttpStatusCode.OK)
                throw new Exception();
        }
    }
}
