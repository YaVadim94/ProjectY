using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectY.Backend.Data.Entities;

namespace ProjectY.Backend.Data.Extensions
{
    /// <summary>
    /// Расширения для конфигуратора сущностей БД 
    /// </summary>
    public static class EntityTypeConfigurationExtensions
    {
        /// <summary>
        /// Сконфигурировать базовые поля сущности
        /// </summary>
        public static EntityTypeBuilder<T> ConfigureAsEntityBase<T>(this EntityTypeBuilder<T> builder)
            where T : EntityBase
        {
            //TODO: хочу попробовать другой способ выдачи индексов
            builder.Property(x => x.Id).UseIdentityByDefaultColumn().HasComment("Идентификатор записи");
            builder.Property(x => x.CreatedDate).HasComment("Дата создания");
            builder.Property(x => x.ModifiedDate).HasComment("Дата последнего обновления");

            return builder;
        }
    }
}
