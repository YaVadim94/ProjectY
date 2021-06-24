using AutoMapper;
using ProjectY.Application.Core.Extensions;
using ProjectY.Backend.Application.Logic.Models.Home;
using ProjectY.Backend.Data.Entities;
using System;

namespace ProjectY.Backend.Application.Logic.Profiles
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
