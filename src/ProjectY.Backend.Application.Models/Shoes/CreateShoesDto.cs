namespace ProjectY.Backend.Application.Models.Shoes
{
    /// <summary>
    /// Модель для создания обуви.
    /// </summary>
    public class CreateShoesDto
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
