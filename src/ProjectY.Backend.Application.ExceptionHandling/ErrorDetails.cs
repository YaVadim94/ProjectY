using Newtonsoft.Json;

namespace ProjectY.Backend.Application.ExceptionHandling
{
    /// <summary>
    /// Модель для информации об ошибке.
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// Наименование ошибки.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код ошибки.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Сериализация текущего экземпляра в строку.
        /// </summary>
        public override string ToString() => JsonConvert.SerializeObject(this);

    }
}
