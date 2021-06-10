using System.ComponentModel.DataAnnotations;

namespace ProjectY.Web.Api.Contracts.Requests
{
    /// <summary>
    /// Модель для создания сущности Home.
    /// </summary>
    public class CreateHomeDto
    {
        /// <summary>
        /// Номер.
        /// </summary>
        [Required]
        public int Number { get; set; }
    }
}
