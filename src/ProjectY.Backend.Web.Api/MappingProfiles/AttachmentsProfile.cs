using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectY.Backend.Application.Core.Extensions;
using ProjectY.Backend.Application.Models.Attachments;
using ProjectY.Backend.Application.Models.Attachments.Commands;
using ProjectY.Shared.Contracts.AttachmentsController;

namespace ProjectY.Backend.Web.Api.MappingProfiles
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

            CreateMap<IFormFile, PutObjectCommand>()
                .IgnoreMember(d => d.InputStream)
                .MapMember(d => d.FileSize, s => s.Length)
                .MapMember(d => d.Key, _ => Guid.NewGuid().ToString());
        }
    }
}
