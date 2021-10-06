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

        /// <summary>
        /// Переопределение метода создания моделей
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        /// <summary> Обувь. </summary>
        public DbSet<Shoes> Shoes { get; set; }

        /// <summary> Приложения(объекты) </summary>
        public DbSet<Attachment> Attacments { get; set; }

    }
}
