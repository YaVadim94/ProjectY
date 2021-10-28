using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectY.Backend.Application.Core.Interfaces;
using ProjectY.Backend.Application.Models.Shoes;
using ProjectY.Backend.Application.Models.Shoes.Queries;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Logic.Handlers.ShoesHandlers.QueriesHandlers
{
    /// <summary>
    /// Класс для обработки запроса на получение всех моделей обуви.
    /// </summary>
    public class GetAllShoesQueryHandler : IRequestHandler<GetAllShoesQuery, IEnumerable<ShoesDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Shoes> _repository;

        /// <summary>
        /// Конструктор класса для обработки запроса на получение всех моделей обуви.
        /// </summary>
        public GetAllShoesQueryHandler(IMapper mapper, IRepository<Shoes> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Метод, вызываемый для обработки запроса.
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список обуви</returns>
        public async Task<IEnumerable<ShoesDto>> Handle(GetAllShoesQuery query, CancellationToken cancellationToken)
        {
            var allShoes = await _repository.ListAll();

            return _mapper.Map<IEnumerable<ShoesDto>>(allShoes);
        }
    }
}
