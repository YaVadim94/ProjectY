using System;
using AutoMapper;
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
                .ForMember(d => d.CreatedDate,
                    opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(d => d.ModifiedDate,
                    opt => opt.MapFrom(src => DateTime.Now))
                .ReverseMap();
            CreateMap<CreateHomeContract, CreateHomeDto>();
            CreateMap<HomeDto, HomeContract>();
        }
    }
}
