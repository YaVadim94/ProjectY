using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectY.Backend.Application.Models.Shoes;
using ProjectY.Backend.Application.Models.Shoes.Queries;
using ProjectY.Backend.Data.Repositories.Query;

namespace ProjectY.Backend.Application.Logic.Handlers.ShoesHandlers.QueryHandlers
{
    /// <summary>
    /// Класс для обработки запроса на получение всех моделей обуви.
    /// </summary>
    public class GetAllShoesQueryHandler : IRequestHandler<GetAllShoesQuery, IEnumerable<ShoesDto>>
    {
        private readonly IShoesQueryRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор класса для обработки запроса на получение всех моделей обуви.
        /// </summary>
        public GetAllShoesQueryHandler(IShoesQueryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Обрабочик запроса на получение всех моделей обуви.
        /// </summary>
        public async Task<IEnumerable<ShoesDto>> Handle(GetAllShoesQuery request, CancellationToken cancellationToken)
        {
            var allShoes = await _repository.GetAll();

            return _mapper.Map<IEnumerable<ShoesDto>>(allShoes);
        }
    }
}
