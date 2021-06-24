using System;

namespace ProjectY.Web.Api.Contracts.Home
{
    /// <summary>
    /// Контракт для сущности Home.
    /// </summary>
    public class HomeContract
    {
        /// <summary>
        /// Номер.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
