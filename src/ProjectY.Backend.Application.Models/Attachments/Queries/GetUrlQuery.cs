using MediatR;

namespace ProjectY.Backend.Application.Models.Attachments.Queries
{
    /// <summary>
    /// Запрос адреса объекта
    /// </summary>
    public class GetUrlQuery : IRequest<AttachmentDto>
    {
        /// <summary>
        /// Идентификатор приложения
        /// </summary>
        public long AttachmentId { get; set; }
    }
}
