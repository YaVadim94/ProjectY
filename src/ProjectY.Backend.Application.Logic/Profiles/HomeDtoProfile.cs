using System;
using AutoMapper;
using ProjectY.Backend.Application.Core.Extensions;
using ProjectY.Backend.Application.Logic.Models.Home;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Logic.Profiles
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeDtoProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public HomeDtoProfile()
        {
            CreateMap<HomeDto, Home>()
                .MapMember(d => d.CreatedDate, src => DateTime.Now)
                .MapMember(d => d.ModifiedDate, src => DateTime.Now)
                .MapMember(d => d.Number, src => src.Number)
                .ForAllOtherMembers(x => x.Ignore())
                ;

            CreateMap<Home, HomeDto>();

            CreateMap<CreateHomeDto, Home>()
                .MapMember(d => d.CreatedDate, src => DateTime.Now)
                .MapMember(d => d.ModifiedDate, src => DateTime.Now)
                .MapMember(d => d.Number, src => src.Number)
                .ForAllOtherMembers(x => x.Ignore())
                ;
        }
    }
}
