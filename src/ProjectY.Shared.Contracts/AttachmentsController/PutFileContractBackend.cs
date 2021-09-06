using Microsoft.AspNetCore.Http;

namespace ProjectY.Shared.Contracts.AttachmentsController
{
    /// <summary>
    /// Контакт для помещения файла в хранилище
    /// </summary>
    public class PutFileContractBackend
    {
        /// <summary> Наименование файла </summary>
        public string FileName { get; set; }

        /// <summary> Файл </summary>
        public IFormFile File { get; set; }
    }
}
