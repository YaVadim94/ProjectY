using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectY.Backend.Data.Entities;
using ProjectY.Backend.Data.Repositories.Query.Base;

namespace ProjectY.Backend.Data.Repositories.Query
{
    public interface IShoesQueryRepository : IQueryRepository<Shoes>
    {
        // Кастомные запросы для обувной сущности.
    }
}
