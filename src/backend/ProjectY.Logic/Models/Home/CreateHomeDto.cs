using System.ComponentModel.DataAnnotations;

namespace ProjectY.Logic.Models.Home
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
