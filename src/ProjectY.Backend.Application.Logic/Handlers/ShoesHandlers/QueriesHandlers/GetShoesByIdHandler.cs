using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
    public class GetShoesByIdHandler : BaseRequestHandler<GetShoesByIdQuery, ShoesDto>
    {
        private readonly IRepository<Shoes> _repository;

        /// <summary>
        /// Конструктор класса для обработки запроса на получение всех моделей обуви.
        /// </summary>
        public GetShoesByIdHandler(IMapper mapper, ILogger<GetShoesByIdHandler> logger, IRepository<Shoes> repository)
            : base(mapper, logger)
        {
            _repository = repository;
        }

        /// <summary>
        /// Обрабочик запроса на получение всех моделей обуви.
        /// </summary>
        protected override async Task<ShoesDto> Execute(GetShoesByIdQuery query, CancellationToken cancellationToken = default)
        {
            var spec = new ShoesCrtiteriaSpec(query.ShoesId);

            var shoes = await _repository.First(spec, cancellationToken);

            return Mapper.Map<ShoesDto>(shoes);
        }
    }
}
