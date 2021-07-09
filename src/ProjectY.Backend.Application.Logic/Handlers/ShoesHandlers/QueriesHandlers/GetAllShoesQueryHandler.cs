using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectY.Backend.Application.Core.Extensions;
using ProjectY.Backend.Application.Models.Shoes;
using ProjectY.Backend.Application.Models.Shoes.Queries;
using ProjectY.Backend.Data;

namespace ProjectY.Backend.Application.Logic.Handlers.ShoesHandlers.QueriesHandlers
{
    /// <summary>
    /// Класс для обработки запроса на получение всех моделей обуви.
    /// </summary>
    public class GetAllShoesQueryHandler : IRequestHandler<GetAllShoesQuery, IEnumerable<ShoesDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор класса для обработки запроса на получение всех моделей обуви.
        /// </summary>
        public GetAllShoesQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Обрабочик запроса на получение всех моделей обуви.
        /// </summary>
        public async Task<IEnumerable<ShoesDto>> Handle(GetAllShoesQuery request, CancellationToken cancellationToken)
        {
            var allShoes = await _context.Shoes
                .AsNoTracking()
                .ProjectTo<ShoesDto>(_mapper.ConfigurationProvider)
                .ApplyOptions(request.ODataOptions)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ShoesDto>>(allShoes);
        }
    }
}
