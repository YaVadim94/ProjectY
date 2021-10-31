using Microsoft.Extensions.Configuration;
using ProjectY.Backend.Data.Entities;
using ProjectY.Backend.Data.Repositories.Query.Base;

namespace ProjectY.Backend.Data.Repositories.Query
{
    public class ShoesQueryRepository : QueryRepository<Shoes>, IShoesQueryRepository
    {
        public ShoesQueryRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
