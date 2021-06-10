using System;

namespace ProjectY.Web.Api.Contracts.Responses
{
    /// <summary>
    /// Модель созданной сущности Home.
    /// </summary>
    public class CreatedHomeDto
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
