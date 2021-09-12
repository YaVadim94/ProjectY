using System.IO;

namespace ProjectY.Backend.Application.AmazonS3.Models
{
    /// <summary>
    /// Дто для помещения объектов в хранилище
    /// </summary>
    public class PutObjectDto
    {
        /// <summary> Ключ объекта </summary>
        public string Key { get; set; }

        /// <summary> Тип контента </summary>
        public string ContentType { get; set; }

        /// <summary> Поток к объекту </summary>
        public Stream InputStream { get; set; }

        /// <summary> Наименование файла </summary>
        public string FileName { get; set; }

        /// <summary> Размер файла </summary>
        public long FileSize { get; set; }
    }
}
