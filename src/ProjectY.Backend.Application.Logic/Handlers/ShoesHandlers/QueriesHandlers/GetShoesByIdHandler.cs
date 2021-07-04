using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectY.Backend.Application.Models.Shoes;
using ProjectY.Backend.Application.Models.Shoes.Queries;
using ProjectY.Backend.Data;

namespace ProjectY.Backend.Application.Logic.Handlers.ShoesHandlers.QueriesHandlers
{
    /// <summary>
    /// Класс для обработки запроса на получение всех моделей обуви.
    /// </summary>
    public class GetShoesByIdHandler : IRequestHandler<GetShoesByIdQuery, ShoesDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор класса для обработки запроса на получение всех моделей обуви.
        /// </summary>
        public GetShoesByIdHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Обрабочик запроса на получение всех моделей обуви.
        /// </summary>
        public async Task<ShoesDto> Handle(GetShoesByIdQuery request, CancellationToken cancellationToken)
        {
            var shoes = await _context.Shoes
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == request.ShoesId, cancellationToken);

            return _mapper.Map<ShoesDto>(shoes);
        }
    }
}
