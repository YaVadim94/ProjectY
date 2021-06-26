using System.Threading.Tasks;
using ProjectY.Backend.Application.Logic.Models.Home;

namespace ProjectY.Backend.Application.Logic.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITestService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="homeDto"></param>
        /// <returns></returns>
        Task<HomeDto> CreateAsync(CreateHomeDto homeDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HomeDto> GetByIdAsync(long id);
    }
}
