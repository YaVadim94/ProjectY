using System.Net.Http;

namespace ProjectY.Shared.Contracts.AttachmentsController
{
    /// <summary>
    /// Контакт для помещения файла в хранилище
    /// </summary>
    public class PutFileContractFrontend
    {
        /// <summary> Наименование файла </summary>
        public string FileName { get; set; }

        /// <summary> Файл </summary>
        public MultipartFormDataContent File { get; set; }
    }
}
