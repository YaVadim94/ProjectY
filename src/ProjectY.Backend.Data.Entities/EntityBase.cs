using System;

namespace ProjectY.Backend.Data.Entities
{
    /// <summary>
    /// Базовая сущность базы данных
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }

        /// <summary> Дата создания </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary> Дата изменения </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
