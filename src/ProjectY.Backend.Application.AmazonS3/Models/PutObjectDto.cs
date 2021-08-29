using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectY.Backend.Application.AmazonS3.Models
{
    /// <summary>
    /// Дто для помещения объектов в хранилище
    /// </summary>
    public class PutObjectDto
    {
        /// <summary> Наименование объекта </summary>
        public string Key { get; set; }

        /// <summary> Тип контента </summary>
        public string ContentType { get; set; }

        /// <summary> Наименование бакета </summary>
        public string BucketName { get; set; }

        /// <summary> Поток к объекту </summary>
        public Stream InputStream { get; set; }
    }
}
