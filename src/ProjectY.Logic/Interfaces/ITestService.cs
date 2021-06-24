using System.Threading.Tasks;
using ProjectY.Backend.Application.Logic.Models.Home;

namespace ProjectY.Backend.Application.Logic.Interfaces
{
    public interface ITestService
    {
        Task<HomeDto> CreateAsync(CreateHomeDto homeDto);

        Task<HomeDto> GetByIdAsync(long id);
    }
}
