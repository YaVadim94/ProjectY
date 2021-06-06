using Microsoft.EntityFrameworkCore;
using ProjectY.Data.Entities;

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

        public DbSet<Home> Homes { get; set; }
    }
}
