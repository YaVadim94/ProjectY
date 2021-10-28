using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProjectY.Backend.Application.Core.Interfaces;
using ProjectY.Backend.Application.Core.Specifications.Shoes;
using ProjectY.Backend.Application.Models.Shoes;
using ProjectY.Backend.Application.Models.Shoes.Queries;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Logic.Handlers.ShoesHandlers.QueriesHandlers
{
    /// <summary>
    /// Класс для обработки запроса на получение модели обуви по ее идентификатору.
    /// </summary>
    public class GetShoesByIdQueryHandler : IRequestHandler<GetShoesByIdQuery, ShoesDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Shoes> _repository;

        /// <summary>
        /// Конструктор класса для обработки запроса на получение всех моделей обуви.
        /// </summary>
        public GetShoesByIdQueryHandler(IMapper mapper, IRepository<Shoes> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Метод, вызываемый для обработки запроса.
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Обувь</returns>
        public async Task<ShoesDto> Handle(GetShoesByIdQuery query, CancellationToken cancellationToken)
        {
            var spec = new ShoesCrtiteriaSpec(query.ShoesId);

            var shoes = await _repository.First(spec);

            return _mapper.Map<ShoesDto>(shoes);
        }
    }
}
