using Ardalis.Specification;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Application.Core.Specifications.Shoes
{
    /// <summary>
    /// Спецификация на получение модели обуви.
    /// </summary>
    public sealed class ShoesCrtiteriaSpec : Specification<Data.Entities.Shoes>
    {
        /// <summary>
        /// Конструктор спецификации на получение модели обуви.
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="color">Цвет</param>
        public ShoesCrtiteriaSpec(long id = default, int color = default)
        {
            if (id != default)
            {
                Query.Where(shoes => shoes.Id == id);
            }

            if (color != default)
            {
                Query.Where(shoes => shoes.Color == color);
            }
            
            Query.AsNoTracking();
        }
    }
}
