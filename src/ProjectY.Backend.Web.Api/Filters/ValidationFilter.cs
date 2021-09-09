using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectY.Backend.Shared.BaseExceptions;
using ProjectY.Backend.Web.Api.Exceptions;

namespace ProjectY.Backend.Web.Api.Filters
{
    /// <summary>
    /// Фильтр для валидации данных.
    /// </summary>
    public class ValidationFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Метод вызываемый после привязки данных к модели и перед самим методом действия.
        /// </summary>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var validationErrors = context.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors, (name, value) => new { name.Key, value.ErrorMessage })
                    .Select(x => new ValidationError { FieldName = x.Key, Message = x.ErrorMessage }).ToArray();

                throw new ContractValidationException(validationErrors);
            }

            await next();
        }
    }
}
