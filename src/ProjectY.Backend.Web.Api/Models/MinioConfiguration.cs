namespace ProjectY.Backend.Web.Api.Models
{
    /// <summary>
    /// Конфигурации для Minio (объектное хранилище)
    /// </summary>
    public class MinioConfiguration
    {
        /// <summary> Адрес </summary>
        public string Url { get; set; }

        /// <summary> Ключ доступа </summary>
        public string AccessKey { get; set; }

        /// <summary> Секретный ключ </summary>
        public string SecretKey { get; set; }
    }
}
