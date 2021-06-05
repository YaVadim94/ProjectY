using Microsoft.EntityFrameworkCore;

namespace ProjectY.Data
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
