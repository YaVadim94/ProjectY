using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectY.Backend.Application.AmazonS3.Models
{
    /// <summary>
    /// Дто для удаления объекта из хранилица
    /// </summary>
    public class DeleteObjectDto
    {
        /// <summary> Ключ объекта </summary>
        public string Key { get; set; }

        /// <summary> Наименование бакета </summary>
        public string BucketName { get; set; }
    }
}
