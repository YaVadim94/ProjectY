using ProjectY.Backend.Application.Core.Exceptions;

namespace ProjectY.Backend.Web.Api.Exceptions
{
    /// <summary>
    /// Исключение при валидации данных контракта.
    /// </summary>
    public class ContractValidationException : ValidationException
    {
        /// <summary>
        /// Конструктор исключения при валидации данных контракта.
        /// </summary>
        public ContractValidationException(params ValidationError[] errors) : base(errors) { }
    }
}
