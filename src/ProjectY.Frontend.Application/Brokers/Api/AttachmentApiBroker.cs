using System.Net.Http;
using System.Threading.Tasks;
using ProjectY.Frontend.Application.Brokers.Api.Interfaces;
using ProjectY.Shared.Contracts.AttachmentsController;

namespace ProjectY.Frontend.Application.Brokers.Api
{
    /// <summary>
    /// Брокер для работы с тестовым контроллером
    /// </summary>
    public class AttachmentApiBroker : ApiBrokerBase, IAttachmentApiBroker
    {
        /// <summary>
        /// Брокер для работы с тестовым контроллером
        /// </summary>
        public AttachmentApiBroker(HttpClient client) : base(client) { }

        /// <summary> Относительный урл контроллера бекенда </summary>
        protected override string ControllerUrl => "api/attachments";

        /// <summary>
        /// Загрузить файл в хранилище
        /// </summary>
        public async Task<object> Upload(PutFileContractFrontend fileContract) =>
            await PostAsync<PutFileContractFrontend, object>(string.Empty, fileContract);

        /// <summary>
        /// Получить адрес файла по идентификатору
        /// </summary>
        public async Task<AttachmentContract> GetUrl(long attachmentId) =>
            await GetAsync<AttachmentContract>(attachmentId.ToString());
    }
}
