using ProjectY.Backend.Data.Entities;
using ProjectY.Backend.Data.Repositories.Command.Base;

namespace ProjectY.Backend.Data.Repositories.Command
{
    public class ShoesCommandRepository : CommandRepository<Shoes>, IShoesCommandRepository
    {
        public ShoesCommandRepository(DataContext context) : base(context)
        {
        }
    }
}
