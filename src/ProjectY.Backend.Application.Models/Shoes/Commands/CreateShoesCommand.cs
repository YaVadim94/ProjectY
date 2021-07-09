using MediatR;

namespace ProjectY.Backend.Application.Models.Shoes.Commands
{
    /// <summary>
    /// Модель для создания обуви.
    /// </summary>
    public class CreateShoesCommand : IRequest<ShoesDto>
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
