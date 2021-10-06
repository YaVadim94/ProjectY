using System.Threading.Tasks;
using ProjectY.Shared.Contracts.AttachmentsController;

namespace ProjectY.Frontend.Application.Brokers.Api.Interfaces
{
    /// <summary>
    /// Брокер для работы с приложениями(файлами/объектами)
    /// </summary>
    public interface IAttachmentApiBroker
    {
        /// <summary>
        /// Загрузить файл в хранилище
        /// </summary>
        Task<object> Upload(PutFileContractFrontend fileContract);

        /// <summary>
        /// Получить адрес файла по идентификатору
        /// </summary>
        Task<AttachmentContract> GetUrl(long attachmentId);
    }
}
