using System;
using AutoMapper;
using ProjectY.Application.Core.Extensions;
using ProjectY.Data.Entities;
using ProjectY.Logic.Models.Home;
using ProjectY.Web.Api.Contracts.Home;

namespace ProjectY.Web.Api.Profiles
{
    /// <summary>
    /// Класс для конфигурации маппинга.
    /// </summary>
    public class HomeProfile : Profile
    {
        /// <summary>
        /// Конструктор класса для конфигурации маппинга.
        /// </summary>
        public HomeProfile()
        {
            CreateMap<HomeDto, Home>()
                .MapMember(d => d.CreatedDate, src => DateTime.Now)
                .MapMember(d => d.ModifiedDate, src => DateTime.Now)
                .ReverseMap();
            CreateMap<CreateHomeContract, CreateHomeDto>();
            CreateMap<HomeDto, HomeContract>();
        }
    }
}
