using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectY.Backend.Application.Core.Interfaces;
using ProjectY.Backend.Application.Models.Shoes.Commands;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Logic.Handlers.ShoesHandlers.CommandHandlers
{
    /// <summary>
    /// Класс для обработки команды на создание модели обуви.
    /// </summary>
    public class CreateShoesCommandHandler : IRequestHandler<CreateShoesCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Shoes> _repository;

        /// <summary>
        /// Конструктор класса для обработки команды на созадние модели обуви.
        /// </summary>
        public CreateShoesCommandHandler(IMapper mapper, IRepository<Shoes> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Метод, вызываемый для обработки запроса.
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Unit as void</returns>
        public async Task<Unit> Handle(CreateShoesCommand request, CancellationToken cancellationToken)
        {
            var shoes = _mapper.Map<Shoes>(request);

            await _repository.Add(shoes);

            return new Unit();
        }
    }
}
