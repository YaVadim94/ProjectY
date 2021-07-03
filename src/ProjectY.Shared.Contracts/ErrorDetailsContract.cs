using Newtonsoft.Json;

namespace ProjectY.Shared.Contracts
{
    /// <summary>
    /// Модель для информации об ошибке.
    /// </summary>
    public class ErrorDetailsContract
    {
        /// <summary>
        /// Наименование ошибки.
        /// </summary>
        public string Name { get; set; }

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
