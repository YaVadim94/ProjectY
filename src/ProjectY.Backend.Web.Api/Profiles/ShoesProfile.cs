using AutoMapper;
using ProjectY.Backend.Application.Logic.Models.Shoes;
using ProjectY.Shared.Contracts.ShoesController;

namespace ProjectY.Backend.Web.Api.Profiles
{
    /// <summary>
    /// Класс для конфигурации маппинга.
    /// </summary>
    public class ShoesProfile : Profile
    {
        /// <summary>
        /// Конструктор класса для конфигурации маппинга.
        /// </summary>
        public ShoesProfile()
        {
            CreateMap<CreateShoesContract, CreateShoesDto>();
            CreateMap<ShoesDto, ShoesContracts>();
        }
    }
}
