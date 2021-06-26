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
    public class HomeProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public HomeProfile()
        {
            CreateMap<HomeDto, Home>()
                .MapMember(d => d.CreatedDate, src => DateTime.Now)
                .MapMember(d => d.ModifiedDate, src => DateTime.Now)
                .ReverseMap();
        }
    }
}
