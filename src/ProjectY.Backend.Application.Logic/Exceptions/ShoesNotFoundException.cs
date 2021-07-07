using System;
using System.Net;

namespace ProjectY.Backend.Application.Logic.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ShoesNotFoundException : Exception
    {
        /// <summary>
        /// Код ошибки.
        /// </summary>
        public int StatusCode => (int)HttpStatusCode.NotFound;

        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public override string Message => "По запросу не найдено ни одной модели обуви";
    }
}
