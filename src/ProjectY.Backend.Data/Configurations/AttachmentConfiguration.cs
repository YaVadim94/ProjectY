using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectY.Backend.Data.Entities;
using ProjectY.Backend.Data.Extensions;

namespace ProjectY.Backend.Data.Configurations
{
    /// <summary>
    /// Конфигурация для <see cref="Attachment"/>
    /// </summary>
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        /// <summary>
        /// Конфигурация для <see cref="Attachment"/>
        /// </summary>
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable("attachments");

            builder.ConfigureAsEntityBase();

            builder.Property(x => x.Key).HasComment("Ключ объекта");
            builder.Property(x => x.FileName).HasComment("Наименование файла");
            builder.Property(x => x.FileSize).HasComment("Размер файла");
            builder.Property(x => x.ContentType).HasComment("Тип контента файла");
            builder.Property(x => x.Url).HasComment("Адрес объекта");
        }
    }
}
