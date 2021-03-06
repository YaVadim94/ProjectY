using AutoMapper;
using ProjectY.Backend.Application.Models.Shoes;
using ProjectY.Backend.Application.Models.Shoes.Commands;
using ProjectY.Shared.Contracts.ShoesController;

namespace ProjectY.Backend.Web.Api.MappingProfiles
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
            CreateMap<CreateShoesContract, CreateShoesCommand>();
            CreateMap<ShoesDto, ShoesContracts>();
        }
    }
}
