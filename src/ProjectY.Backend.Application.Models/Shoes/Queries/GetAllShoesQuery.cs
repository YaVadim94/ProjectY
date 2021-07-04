using System.Collections.Generic;
using MediatR;

namespace ProjectY.Backend.Application.Models.Shoes.Queries
{
    /// <summary>
    /// Запрос на получение всех моделей обуви.
    /// </summary>
    public class GetAllShoesQuery : IRequest<IEnumerable<ShoesDto>>
    {
    }
}
