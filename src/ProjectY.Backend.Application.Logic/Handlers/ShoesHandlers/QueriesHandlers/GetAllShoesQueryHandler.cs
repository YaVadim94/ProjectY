using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectY.Backend.Application.Core.Extensions;
using ProjectY.Backend.Application.Core.Interfaces;
using ProjectY.Backend.Application.Models.Shoes;
using ProjectY.Backend.Application.Models.Shoes.Queries;
using ProjectY.Backend.Data;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Logic.Handlers.ShoesHandlers.QueriesHandlers
{
    /// <summary>
    /// Класс для обработки запроса на получение всех моделей обуви.
    /// </summary>
    public class GetAllShoesQueryHandler : BaseRequestHandler<GetAllShoesQuery, IEnumerable<ShoesDto>>
    {
        private readonly IRepository<Shoes> _repository;

        /// <summary>
        /// Конструктор класса для обработки запроса на получение всех моделей обуви.
        /// </summary>
        public GetAllShoesQueryHandler(IMapper mapper, ILogger<GetAllShoesQueryHandler> logger, IRepository<Shoes> repository)
            : base(mapper, logger)
        {
            _repository = repository;
        }

        /// <summary>
        /// Исполнение запроса на получение всех моделей обуви.
        /// </summary>
        protected override async Task<IEnumerable<ShoesDto>> Execute(GetAllShoesQuery query, CancellationToken cancellationToken)
        {
            var allShoes = await _repository.ListAll(cancellationToken);
            
            return Mapper.Map<IEnumerable<ShoesDto>>(allShoes);
        }
        
        // var allShoes = await _context.Shoes
            //     .AsNoTracking()
            //     .ProjectTo<ShoesDto>(_mapper.ConfigurationProvider)
            //     .ApplyOptions(query.ODataOptions)
            //     .ToListAsync(cancellationToken);
            //
            // return _mapper.Map<IEnumerable<ShoesDto>>(allShoes);
    }
}
