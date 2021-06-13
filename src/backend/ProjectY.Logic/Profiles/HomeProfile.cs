using System;
using AutoMapper;
using ProjectY.Application.Core.Extensions;
using ProjectY.Data.Entities;
using ProjectY.Logic.Models.Home;

namespace ProjectY.Application.Logic.Profiles
{
    public class HomeProfile : Profile
    {
        public HomeProfile()
        {
            CreateMap<HomeDto, Home>()
                .MapMember(d => d.CreatedDate, src => DateTime.Now)
                .MapMember(d => d.ModifiedDate, src => DateTime.Now)
                .ReverseMap();
        }
    }
}
