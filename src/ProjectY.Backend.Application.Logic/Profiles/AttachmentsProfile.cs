using System;
using AutoMapper;
using ProjectY.Backend.Application.AmazonS3.Models;
using ProjectY.Backend.Application.Core.Extensions;
using ProjectY.Backend.Application.Models.Attachments;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Logic.Profiles
{
    /// <summary>
    /// Профиль маппинга для приложений
    /// </summary>
    public class AttachmentsProfile : Profile
    {
        /// <summary>
        /// Профиль маппинга для приложений
        /// </summary>
        public AttachmentsProfile()
        {
            CreateMap<PutObjectDto, Attachment>()
                .MapMember(d => d.CreatedDate, src => DateTime.Now)
                .MapMember(d => d.ModifiedDate, src => DateTime.Now)
                .IgnoreMember(d => d.Url)
                .IgnoreMember(d => d.Id);

            CreateMap<Attachment, AttachmentDto>();
        }
    }
}
