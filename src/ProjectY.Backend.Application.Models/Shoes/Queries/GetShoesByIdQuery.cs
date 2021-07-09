using MediatR;

namespace ProjectY.Backend.Application.Models.Shoes.Queries
{
    /// <summary>
    /// Запрос на получение модели обуви по ее идентификатору.
    /// </summary>
    public class GetShoesByIdQuery : IRequest<ShoesDto>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long ShoesId { get; }

        /// <summary>
        /// Конструктор класса запроса на получение модели обуви по ее идентификатору.
        /// </summary>
        /// <param name="id"></param>
        public GetShoesByIdQuery(long id)
        {
            ShoesId = id;
        }
    }
}
