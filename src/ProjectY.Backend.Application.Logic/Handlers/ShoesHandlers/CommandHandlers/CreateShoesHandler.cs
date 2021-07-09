using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectY.Backend.Application.Models.Shoes;
using ProjectY.Backend.Application.Models.Shoes.Commands;
using ProjectY.Backend.Data;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Logic.Handlers.ShoesHandlers.CommandHandlers
{
    /// <summary>
    /// Класс для обработки команды на созадние модели обуви.
    /// </summary>
    public class CreateShoesHandler : IRequestHandler<CreateShoesCommand, ShoesDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор класса для обработки команды на созадние модели обуви.
        /// </summary>
        public CreateShoesHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Обработчик команды на созадние модели обуви.
        /// </summary>
        public async Task<ShoesDto> Handle(CreateShoesCommand request, CancellationToken cancellationToken)
        {
            var createdShoes = _mapper.Map<Shoes>(request);

            await _context.AddAsync(createdShoes, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ShoesDto>(createdShoes);
        }
    }
}
