using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectY.Backend.Application.Models.Shoes;
using ProjectY.Backend.Application.Models.Shoes.Queries;
using ProjectY.Backend.Data;
using ProjectY.Backend.Data.Repositories.Query;

namespace ProjectY.Backend.Application.Logic.Handlers.ShoesHandlers.QueryHandlers
{
    /// <summary>
    /// Класс для обработки запроса на получение всех моделей обуви.
    /// </summary>
    public class GetShoesByIdHandler : IRequestHandler<GetShoesByIdQuery, ShoesDto>
    {
        private readonly IShoesQueryRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор класса для обработки запроса на получение всех моделей обуви.
        /// </summary>
        public GetShoesByIdHandler(IShoesQueryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Обрабочик запроса на получение всех моделей обуви.
        /// </summary>
        public async Task<ShoesDto> Handle(GetShoesByIdQuery request, CancellationToken cancellationToken)
        {
            var shoes = await _repository.GetById(request.ShoesId);

            return _mapper.Map<ShoesDto>(shoes);
        }
    }
}
