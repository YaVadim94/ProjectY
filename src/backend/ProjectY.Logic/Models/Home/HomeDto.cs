using System;

namespace ProjectY.Logic.Models.Home
{
    /// <summary>
    /// Тестовая модель.
    /// </summary>
    public class HomeDto
    {
        /// <summary>
        /// Номер.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Дата изменения.
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
