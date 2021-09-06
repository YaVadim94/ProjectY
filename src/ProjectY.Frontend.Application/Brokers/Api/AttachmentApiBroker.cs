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
        /// <summary> Относительный урл контроллера бекенда </summary>
        protected override string ControllerUrl => "api/test";

        /// <summary>
        /// Брокер для работы с тестовым контроллером
        /// </summary>
        public AttachmentApiBroker(HttpClient client) : base(client) { }

        /// <summary>
        /// Загрузить файл в хранилище
        /// </summary>
        public async Task<object> Upload(PutFileContractFrontend fileContract)
        {
            var response = await PostAsync<PutFileContractFrontend, object>(string.Empty, fileContract);

            return response;
        }
    }
}
