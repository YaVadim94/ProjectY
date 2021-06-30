namespace ProjectY.Backend.Application.Logic.Models.Shoes
{
    /// <summary>
    /// Модель для обуви.
    /// </summary>
    public class ShoesDto
    {
        /// <summary>
        /// Наименование модели.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Артикул модели.
        /// </summary>
        public int VendorCode { get; set; }

        /// <summary>
        /// Тип модели.
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Цвет модели.
        /// </summary>
        public int Color { get; set; }
    }
}
