using System;

namespace ProjectY.Frontend.Application.Exceptions
{
    /// <summary>
    /// Исключение Odata брокера
    /// </summary>
    public class OdataQueryException : Exception
    {
        /// <summary>
        /// Исключение Odata брокера
        /// </summary>
        public OdataQueryException()
            : base("Произошла ошибка при построении Odata запроса") { }
    }
}
