using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectY.Backend.Application.Models.Shoes.Commands;
using ProjectY.Backend.Data.Entities;
using ProjectY.Backend.Data.Repositories.Command;

namespace ProjectY.Backend.Application.Logic.Handlers.ShoesHandlers.CommandHandlers
{
    /// <summary>
    /// Класс для обработки команды на созадние модели обуви.
    /// </summary>
    public class CreateShoesHandler : AsyncRequestHandler<CreateShoesCommand>
    {
        private readonly IMapper _mapper;
        private readonly IShoesCommandRepository _repository;

        /// <summary>
        /// Конструктор класса для обработки команды на созадние модели обуви.
        /// </summary>
        public CreateShoesHandler(IShoesCommandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Обработчик команды на созадние модели обуви.
        /// </summary>
        protected override async Task Handle(CreateShoesCommand request, CancellationToken cancellationToken)
        {
            var createdShoes = _mapper.Map<Shoes>(request);

            await _repository.Add(createdShoes);
        }
    }
}
