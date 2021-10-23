using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.OData.Query;

namespace ProjectY.Backend.Application.Models.Shoes.Queries
{
    /// <summary>
    /// Запрос на получение всех моделей обуви.
    /// </summary>
    public class GetAllShoesQuery : IRequest<IEnumerable<ShoesDto>>
    {
        // /// <summary>
        // /// класса запроса на получение всех моделей обуви.
        // /// </summary>
        // public GetAllShoesQuery(ODataQueryOptions<ShoesDto> oDataQueryOptions)
        // {
        //     ODataOptions = oDataQueryOptions;
        // }
        //
        // /// <summary>
        // /// Настройки Одаты.
        // /// </summary>
        // public ODataQueryOptions<ShoesDto> ODataOptions { get; set; }
    }
}
