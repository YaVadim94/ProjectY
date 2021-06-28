using Microsoft.EntityFrameworkCore;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Data
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

        /// <summary> Тестовый дата сет </summary>
        public DbSet<Home> Homes { get; set; }

        /// <summary> Обувь. </summary>
        public DbSet<Shoes> Shoes { get; set; }

    }
}
