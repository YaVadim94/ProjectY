using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectY.Data.Entities;
using ProjectY.Logic.Models;

namespace ProjectY.Logic.Interfaces
{
    public interface ITestService
    {
        Task<AddHomeDto> CreateHomeAsync(AddHomeDto homeDto);

        Task<IEnumerable<Home>> GetAllAsync();
    }
}
