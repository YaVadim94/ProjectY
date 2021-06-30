﻿using System;
using AutoMapper;
using ProjectY.Backend.Application.Logic.Models.Shoes;
using ProjectY.Backend.Data.Entities;
using ProjectY.Shared.Core.Extensions;

namespace ProjectY.Backend.Application.Logic.Profiles
{
    /// <summary>
    /// Класс для конфигурации маппинга моделей и сущностей обуви.
    /// </summary>
    public class ShoesDtoProfile : Profile
    {
        /// <summary>
        /// Конструктор класса для конфигурации маппинга моделей и сущностей обуви.
        /// </summary>
        public ShoesDtoProfile()
        {
            CreateMap<ShoesDto, Shoes>()
                .MapMember(d => d.CreatedDate, src => DateTime.Now)
                .MapMember(d => d.ModifiedDate, src => DateTime.Now)
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<ShoesDto, Shoes>();

            CreateMap<CreateShoesDto, Shoes>()
                .MapMember(d => d.CreatedDate, src => DateTime.Now)
                .MapMember(d => d.ModifiedDate, src => DateTime.Now)
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
