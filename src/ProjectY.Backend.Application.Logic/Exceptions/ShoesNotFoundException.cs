using System;

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
        public int StatusCode { get; set; }

        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public override string Message => "По запросу не найдено ни одной модели обуви";
    }
}
