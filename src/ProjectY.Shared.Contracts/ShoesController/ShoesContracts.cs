namespace ProjectY.Shared.Contracts.ShoesController
{
    /// <summary>
    /// Контракт для обуви.
    /// </summary>
    public class ShoesContracts
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
