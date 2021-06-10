using AutoMapper;
using ProjectY.Data.Entities;
using ProjectY.Logic.Models;
using ProjectY.Web.Api.Contracts.Requests;

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
            CreateMap<CreateHomeDto, HomeDto>();
            CreateMap<HomeDto, Home>().ReverseMap();
        }
    }
}
