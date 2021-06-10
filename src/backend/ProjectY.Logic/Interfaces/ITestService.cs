using System.Threading.Tasks;
using ProjectY.Logic.Models.Home;

namespace ProjectY.Logic.Interfaces
{
    public interface ITestService
    {
        Task<HomeDto> CreateAsync(CreateHomeDto homeDto);

        Task<HomeDto> GetByIdAsync(long id);
    }
}
