using AutoMapper;
using ProjectY.Backend.Application.Models.Attachments;
using ProjectY.Shared.Contracts.AttachmentsController;

namespace ProjectY.Backend.Web.Api.Profiles
{
    /// <summary>
    /// Профиль маппинга контрактов приложений
    /// </summary>
    public class AttachmentsProfile : Profile
    {
        /// <summary>
        /// Профиль маппинга контрактов приложений
        /// </summary>
        public AttachmentsProfile()
        {
            CreateMap<AttachmentDto, AttachmentContract>();
        }
    }
}
