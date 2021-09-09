using System;
using System.Collections.Generic;

namespace ProjectY.Backend.Shared.BaseExceptions
{
    /// <summary>
    /// Исключение при валидации данных.
    /// </summary>
    public abstract class ValidationException : Exception
    {
        /// <summary>
        /// Конструктор исключения при валидации данных.
        /// </summary>
        protected ValidationException(params ValidationError[] errors)
        {
            Errors = errors ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Название ошибки.
        /// </summary>
        public virtual string Name => "Ошибка валидации";

        /// <summary>
        /// Список ошибок.
        /// </summary>
        public IList<ValidationError> Errors { get; }
    }

    /// <summary>
    /// Ошибка валидации данных.
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Название поля.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string Message { get; set; }
    }
}
