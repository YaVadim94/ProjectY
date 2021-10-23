using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ProjectY.Backend.Application.Core.Interfaces;
using ProjectY.Backend.Application.Models.Shoes;
using ProjectY.Backend.Application.Models.Shoes.Commands;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Logic.Handlers.ShoesHandlers.CommandHandlers
{
    /// <summary>
    /// Класс для обработки команды на создание модели обуви.
    /// </summary>
    public class CreateShoesHandler : BaseRequestHandler<CreateShoesCommand, ShoesDto>
    {
        private readonly IRepository<Shoes> _repository;

        /// <summary>
        /// Конструктор класса для обработки команды на созадние модели обуви.
        /// </summary>
        public CreateShoesHandler(IMapper mapper, ILogger<CreateShoesHandler> logger, IRepository<Shoes> repository)
            : base(mapper, logger)
        {
            _repository = repository;
        }

        /// <summary>
        /// Исполнение команды на созадние модели обуви.
        /// </summary>
        protected override async Task<ShoesDto> Execute(CreateShoesCommand command, CancellationToken cancellationToken = default)
        {
            var shoes = Mapper.Map<Shoes>(command);

            await _repository.Add(shoes, cancellationToken);

            return Mapper.Map<ShoesDto>(shoes);
        }
    }
}
