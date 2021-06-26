﻿using AutoMapper;
using ProjectY.Backend.Application.Logic.Models.Home;
using ProjectY.Shared.Contracts.TestController;

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
            CreateMap<CreateHomeContract, CreateHomeDto>();
            CreateMap<HomeDto, HomeContract>();
        }
    }
}
