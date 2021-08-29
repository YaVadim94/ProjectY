using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectY.Backend.Application.AmazonS3.Models
{
    /// <summary>
    /// Дто для получения урл файла в хранилище
    /// </summary>
    public class GetObjectUrlDto
    {
        /// <summary> Ключ объекта </summary>
        public string Key { get; set; }

        /// <summary> Наименование бакета </summary>
        public string BucketName { get; set; }
    }
}
