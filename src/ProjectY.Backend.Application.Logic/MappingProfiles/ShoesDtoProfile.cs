using System;
using AutoMapper;
using ProjectY.Backend.Application.Core.Extensions;
using ProjectY.Backend.Application.Models.Shoes;
using ProjectY.Backend.Application.Models.Shoes.Commands;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Logic.MappingProfiles
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
                .IgnoreMember(d => d.Id)
                .MapMember(d => d.CreatedDate, src => DateTime.Now)
                .MapMember(d => d.ModifiedDate, src => DateTime.Now);

            CreateMap<Shoes, ShoesDto>();

            CreateMap<CreateShoesCommand, Shoes>()
                .IgnoreMember(d => d.Id)
                .MapMember(d => d.CreatedDate, src => DateTime.Now)
                .MapMember(d => d.ModifiedDate, src => DateTime.Now);
        }
    }
}
