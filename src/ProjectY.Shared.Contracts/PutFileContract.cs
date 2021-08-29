using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectY.Shared.Contracts
{
    /// <summary>
    /// Контакт для помещения файла в хранилище
    /// </summary>
    public class PutFileContract
    {
        /// <summary> Наименование файла </summary>
        public string FileName { get; set; }

        /// <summary> Файл </summary>
        public IFormFile File { get; set; }
    }
}
